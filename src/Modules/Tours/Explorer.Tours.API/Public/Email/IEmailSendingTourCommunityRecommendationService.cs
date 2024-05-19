using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Tours.API.Public.Email
{
    public interface IEmailSendingTourCommunityRecommendationService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
