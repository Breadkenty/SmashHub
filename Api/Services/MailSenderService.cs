using Microsoft.Extensions.Configuration;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Smash_Combos.Services
{
    public class MailSenderService : IMailSenderService
    {
        private readonly string _address;
        private readonly string _password;

        public MailSenderService(IConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            _address = config["PASSWORDRESET_EMAIL_ADDRESS"];
            _password = config["PASSWORDRESET_EMAIL_PASSWORD"];
        }

        public async Task SendMailAsync(string to, string subject, string plainTextContent, string htmlContent)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_address, _password)
            };

            var fromAddress = new MailAddress(_address);
            var toAddress = new MailAddress(to);

            using var message = new MailMessage() { From = fromAddress, Subject = subject, Body = plainTextContent };

            message.To.Add(toAddress);

            await smtp.SendMailAsync(message);
        }
    }
}
