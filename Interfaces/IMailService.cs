using System.Threading.Tasks;
using WebNDTIT01.Models;


namespace WebNDTIT01.Interfaces
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}
