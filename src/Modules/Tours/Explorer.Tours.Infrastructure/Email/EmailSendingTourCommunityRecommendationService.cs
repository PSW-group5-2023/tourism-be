using System.Net.Mail;
using System.Net;
using Explorer.Tours.API.Public.Email;

namespace Explorer.Tours.Infrastructure.Email
{
    public class EmailSendingTourCommunityRecommendationService: IEmailSendingTourCommunityRecommendationService
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            string mail = "travelo-adventure@outlook.com";
            string password = "traveloadventure123";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password)
            };

            return client.SendMailAsync(
                new MailMessage(
                    from: mail,
                    to: to,
                    subject,
                    body));
        }
    }
}
