using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<UserBackgroundService> _logger;


        public UserBackgroundService(IServiceScopeFactory serviceScopeFactory, ILogger<UserBackgroundService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    await CleanUpAccounts(stoppingToken);
                    await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during background execution.");
            }
        }

        private async Task CleanUpAccounts(CancellationToken stoppingToken)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                    var usersQuery = await userRepository.GetAllGuestAsync();
                    var usersToDelete = await usersQuery
                        .Where(u => (DateTime.UtcNow - u.GuestDateTimeCreated) >= TimeSpan.FromDays(14))
                        .ToListAsync(stoppingToken);

                    if (usersToDelete.Any())
                    {
                        await userRepository.DeleteGuestsAsync(usersToDelete, stoppingToken);
                        _logger.LogInformation($"{usersToDelete.Count} guest accounts were deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while cleaning up accounts.");
            }
        }

    }
}
