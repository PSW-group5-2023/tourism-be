
using Explorer.BuildingBlocks.Infrastructure.Email;
using Explorer.Tours.API.Public;
using FluentResults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class PeriodicHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<PeriodicHostedService> _logger;
        private readonly TimeSpan _period = TimeSpan.FromSeconds(30);
        public PeriodicHostedService(ILogger<PeriodicHostedService> logger, IServiceScopeFactory scopeFactory)
        {

            _logger = logger;
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        }


        private int _executionCount = 0;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            using PeriodicTimer timer = new PeriodicTimer(_period);
            
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var myScopedService = scope.ServiceProvider.GetRequiredService<IRecommenderService>();
                        var rankedTours = myScopedService.GetRecommendedToursByLocation(-1,0,0);
                        _executionCount++;
                        _logger.LogInformation(
                            $"Executed PeriodicHostedService - Count: {rankedTours.Value.Results.Count}");
                    }
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var emailScopedService = scope.ServiceProvider.GetRequiredService<IEmailSendingService>();
                        emailScopedService.SendEmailAsync("@gmail.com", "hahahahah", "Radi li ovo?");
                    } 
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(
                        $"Failed to execute PeriodicHostedService with exception message {ex.Message}. Good luck next round!");
                }
            }
        }

        
    }
}
