using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        private static readonly string PW_RESET_TEMPLATE_ID = "d-7c4ecbff63104be3a768e56604648bcb"; //The Template Id for the PasswordReset Template on SendGrid

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

        public async Task SendPasswordResetMailAsync(string to, string link)
        {
            var client = new SendGridClient(API_KEY);
            var fromAddress = new EmailAddress("noreply@smashcombos.com", "Smash Combos");
            var toAddress = new EmailAddress(to);

            var msg = new SendGridMessage();
            msg.SetFrom(fromAddress);
            msg.AddTo(toAddress);
            msg.SetTemplateId(PW_RESET_TEMPLATE_ID);
            msg.SetTemplateData(new PasswordResetTemplateData { Link = link });

            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Could not deliver Email");

        }

        private class PasswordResetTemplateData
        {
            [JsonProperty("link")]
            public string Link { get; set; }
        }
    }
}
