using Explorer.BuildingBlocks.Infrastructure.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Email
{
    public class EmailSedningService : IEmailSendingService
    {

        public Task SendEmailAsync(string to, string subject, string body, bool isBodyHtml = false)

        {
            string mail = "viaventura.office@gmail.com";
            string password = "ilhdapupjkztntyp";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password)
            };


            var mailMessage = new MailMessage
            {
                From = new MailAddress(mail),
                To = { to },
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            };

            return client.SendMailAsync(mailMessage);

        }
    }
}
