using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using WebNDTIT01.Models;
using WebNDTIT01.Interfaces;

namespace WebNDTIT01.Services
{
    public class EmailService : IEmailService
    {
        public ILogger<EmailService> _logger { get; }
        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public void Send(MailRequest mailRequest)
        {
            try
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

                //create email
                var email = new MimeMessage();
                //email.From.Add(MailboxAddress.Parse(mailRequest.From ?? config.GetValue<string>("MailSettings:From")));
                email.From.Add(MailboxAddress.Parse(config.GetValue<string>("MailSettings:From")));
                email.To.Add(MailboxAddress.Parse(mailRequest.To));
                email.Subject = mailRequest.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = mailRequest.Body };

                //send email
                using var smtp = new SmtpClient();
                smtp.Connect(config.GetValue<string>("MailSettings:Host"), config.GetValue<int>("MailSettings:Port"), SecureSocketOptions.StartTls);
                smtp.Authenticate(config.GetValue<string>("MailSettings:Username"), config.GetValue<string>("MailSettings:Password"));
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }

}