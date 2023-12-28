
using Explorer.BuildingBlocks.Infrastructure.Email;
using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Explorer.Stakeholders.Core.Domain
{
    public class PeriodicHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<PeriodicHostedService> _logger;
        private readonly TimeSpan _period = TimeSpan.FromSeconds(5);
        public PeriodicHostedService(ILogger<PeriodicHostedService> logger, IServiceScopeFactory scopeFactory)
        {

            _logger = logger;
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        }


        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            using PeriodicTimer timer = new PeriodicTimer(_period);
            
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    List<TourDto> tours;
                    List<UserNewsDto> usersToUpdate=new List<UserNewsDto>();
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var myScopedService = scope.ServiceProvider.GetRequiredService<IRecommenderService>();
                        var userNewsService = scope.ServiceProvider.GetRequiredService<IUserNewsService>();
                        var personService = scope.ServiceProvider.GetRequiredService<IPersonService>();
                        var emailScopedService = scope.ServiceProvider.GetRequiredService<IEmailSendingService>();

                        //_logger.LogInformation($"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA {tours.Count}");
                    
                        var usersNews = userNewsService.GetPaged(0, 0).Value.Results.AsQueryable().AsNoTracking().ToList();
                        //_logger.LogInformation($"BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB: {usersNews.Count}");
                        foreach (var userNews in usersNews)
                        {
                            DateTime dateTime = DateTime.UtcNow; 
                            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            long unixTime = (long)(dateTime - unixEpoch).TotalMilliseconds;

                            _logger.LogInformation($"DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD: {unixTime} LLLLLLLLL {userNews.LastSendMs}");

                            if (userNews.SendingPeriod == 0)
                            {
                                continue;
                            }
                            if (unixTime - userNews.LastSendMs >= userNews.SendingPeriod * 1000 * 60)
                            {
                                var reccommendedTours = myScopedService.GetRecommendedToursByLocation((int)userNews.TouristId, 0, 0);
                                var toursForUserRecommended = reccommendedTours.Value.Results;

                                var activeTours = myScopedService.GetActiveToursByLocation((int)userNews.TouristId, 0, 0);
                                var activeToursForUser = activeTours.Value.Results;

                                string toEmail=personService.Get((int)userNews.TouristId).Value.Email;
                                string toNameAndSurname = personService.Get((int)userNews.TouristId).Value.Name + " " + personService.Get((int)userNews.TouristId).Value.Surname;
                                try
                                {
                                    string emailSubject = $"TRAVELO Check out our latest updates.";
                                    string emailBody = @"
                                                            <html>
                                                            <head>
                                                                <style>
                                                                    /* Add other inline styles for specific elements as needed */
                                                                </style>
                                                            </head>
                                                            <body>
                                                                <p>Dear " + toNameAndSurname + @",</p><br>
                                                                <p>Thank you for being a valued user. We have some exciting news to share...</p><br>
                                                                <h3>Recommended top 5 tours only for you!</h3>";

                                    int i = 0;
                                    foreach (var tour in toursForUserRecommended)
                                    {
                                        emailBody += $@"
                                                        <div style=""display: flex; margin: 20px auto; padding: 10px; border: 1px solid #ccc; background-color: #f0f0f0;"">
                                                            <div style=""flex: 1;"">
                                                                <p style=""font-size: 18px; font-weight: bold;"">{tour.Name}</p>
                                                                <p>{tour.Price} RSD</p>
                                                                <p>{tour.Description}</p>
                                                            </div>
                                                        </div>";
                                        i++;
                                        if (i == 5)
                                        {
                                            break;
                                        }
                                    }

                                    emailBody += @"<h3>Look at our top 5 active tours:</h3>";

                                    int j = 0;
                                    foreach (var tour in activeToursForUser)
                                    {
                                        emailBody += $@"
                                                        <div style=""display: flex; margin: 20px auto; padding: 10px; border: 1px solid #ccc; background-color: #f0f0f0;"">
                                                            <div style=""flex: 1;"">
                                                                <p style=""font-size: 18px; font-weight: bold;"">{tour.Name}</p>
                                                                <p>{tour.Price} RSD</p>
                                                                <p>{tour.Description}</p>
                                                            </div>
                                                        </div>";
                                        j++;
                                        if (j == 5)
                                        {
                                            break;
                                        }
                                    }

                                    emailBody += @"
                                                    </body>
                                                    </html>";

                                    emailScopedService.SendEmailAsync(toEmail, emailSubject, emailBody, isBodyHtml: true);
                                    UserNewsDto news = new UserNewsDto(userNews.Id, userNews.TouristId, unixTime, userNews.SendingPeriod);
                                    usersToUpdate.Add(news);
                                    _logger.LogInformation($"CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC {news.Id},{news.LastSendMs} CCCCCCCCCCCC {toEmail}");
                                }
                                catch (Exception ex) { _logger.LogInformation($"GRESKAGRESKAGRGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKA u bloku {ex.Message}. Good luck next round!"); }
                            }
                        }
                        
                    }
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var emailScopedService = scope.ServiceProvider.GetRequiredService<IEmailSendingService>();
                        
                        var userNewsService = scope.ServiceProvider.GetRequiredService<IUserNewsService>();
                        foreach (var news in usersToUpdate.ToList())
                        {
                            userNewsService.Update(news);
                            _logger.LogInformation($"EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE updated {news.Id}");
                        }
                    }

                    }
                catch (Exception ex)
                {
                    _logger.LogInformation($"GRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKAGRESKA to execute PeriodicHostedService with exception message {ex.Message}. Good luck next round!");
                }
            }
        }

        
    }
}