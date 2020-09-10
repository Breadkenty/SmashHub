using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Services
{
    public class MailSenderService : IMailSenderService
    {
        public MailSenderService()
        {
            //Inject the Options(Password & Mail) here, but how do we store them?
        }

        public async Task SendMailAsync(string to, string subject, string body)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("EMAIL-HERE", "PASSWORD-HERE")
            };

            var fromAddress = new MailAddress("EMAIL-HERE");
            var toAddress = new MailAddress(to);

            using var message = new MailMessage() { From = fromAddress, Subject = subject, Body = body };

            message.To.Add(toAddress);

            await smtp.SendMailAsync(message);
        }
    }

    public interface IMailSenderService
    {
        public Task SendMailAsync(string to, string subject, string body);
    }
}
