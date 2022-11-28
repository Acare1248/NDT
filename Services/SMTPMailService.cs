using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using WebNDTIT01.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using WebNDTIT01.Models;
using System.Threading.Tasks;

namespace WebNDTIT01.Services
{
    public class SMTPMailService : IMailService
    {
        public static string From { get; private set; }
        public static string Host { get; private set; }
        public static int Port { get; private set; }
        public static string Username { get; private set; }
        public static string Password { get; private set; }
        public static string DisplayName { get; private set; }


        public static void Mailsetting(IConfiguration configuration)
        {
            From = configuration.GetValue<string>("From");
            Host = configuration.GetValue<string>("Host");
            Port = configuration.GetValue<int>("Port");
            Username = configuration.GetValue<string>("Username");
            Password = configuration.GetValue<string>("Password");
            DisplayName = configuration.GetValue<string>("DisplayName");
        }

        public async Task SendAsync(MailRequest request)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? From);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                
                using var smtp = new SmtpClient();
                smtp.Connect(Host, Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(Username, Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (System.Exception ex)
            {
                
            }
        }
    }
}
