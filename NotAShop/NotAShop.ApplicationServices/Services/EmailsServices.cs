using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using Org.BouncyCastle.Security;
using System.Net.Mail;

namespace NotAShop.ApplicationServices.Services
{
    public class EmailsServices : IEmailsServices
    {


            private readonly IConfiguration _config;
            public EmailsServices
                (
                    IConfiguration config
                )
            {
                _config = config;
            }
        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = "This is the plain text version of the email.",
                HtmlBody = dto.Body 
            };

            if (dto.Attachments != null && dto.Attachments.Count > 0)
            {
                foreach (var filePath in dto.Attachments)
                {
                    if (File.Exists(filePath))
                    {
                        bodyBuilder.Attachments.Add(filePath);
                    }
                }
            }

            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
        }