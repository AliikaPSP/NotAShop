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
            //otsida üles config asukoht ja sinna sisestada muutujad
            //"EmailHost": "smtp.gmail.com",
            //"EmailUserName": "aliika.puusepp@gmail.com",
            //"EmailPassword"; "teie salasõna"

            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = dto.Body
            };

            //kindlasti kasutada mailkit.net.smtp

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            //siin tuleb valida õige port ja kasutada securesocketOptionit
            //autentida
            //saada e-mail
            //vabasta ressurss
            {
                smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);

                smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection( "EmailPassword").Value);

                smtp.Send(email);

                smtp.Disconnect(true);
            }
        }
    }
}
