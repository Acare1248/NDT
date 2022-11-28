using System.Threading.Tasks;
using WebNDTIT01.Models;

namespace WebNDTIT01.Interfaces
{
    public interface IEmailService
    {
        //Task SendAsync(MailRequest mailRequest);
        // void SendAsync(string to, string subject, string body, string from = null);
        //void Send(string to, string subject, string body, string from = null);
        void Send(MailRequest mailRequest);
    }
}
