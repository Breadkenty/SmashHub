using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smash_Combos.Services
{
    public class GridSendMailSenderService : IMailSenderService
    {
        private readonly string API_KEY;

        public GridSendMailSenderService(IConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            API_KEY = config["SENDGRID_API_KEY"];
        }

        public async Task SendMailAsync(string to, string subject, string plainTextContent, string htmlContent)
        {
            var client = new SendGridClient(API_KEY);
            var fromAddress = new EmailAddress("noreply@smashcombos.com", "Smash Combos");
            var toAddress = new EmailAddress(to);
            var msg = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Could not deliver Email");
        }
    }
}
