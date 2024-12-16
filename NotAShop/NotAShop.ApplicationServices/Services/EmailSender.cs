using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NotAShop.Core.ServiceInterface;

namespace NotAShop.ApplicationServices.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var smtpHost = _configuration["EmailHost"];
            var smtpUserName = _configuration["EmailUserName"];
            var smtpPassword = _configuration["EmailPassword"];

            if (string.IsNullOrEmpty(smtpHost))
            {
                throw new ArgumentNullException(nameof(smtpHost), "SMTP host is not configured.");
            }

            var smtpClient = new SmtpClient
            {
                Host = smtpHost,
                Port = 587, 
                Credentials = new NetworkCredential(smtpUserName, smtpPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUserName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }

    }
}
