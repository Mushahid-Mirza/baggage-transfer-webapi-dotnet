using Microsoft.AspNet.Identity;
using BaggageTransfer.Helpers;
using BaggageTransfer.Models;
using System.Threading.Tasks;

namespace BaggageTransfer.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return MailHelper.SendAsync(new EmailMessage
            {
                Body = message.Body,
                To = message.Destination,
                Subject = message.Subject
            });
        }
    }
}
