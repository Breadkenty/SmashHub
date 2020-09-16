using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Services
{
    public interface IMailSenderService
    {
        public Task SendMailAsync(string to, string subject, string plainTextContent, string htmlContent);
        public Task SendPasswordResetMailAsync(string to, string link);
    }
}
