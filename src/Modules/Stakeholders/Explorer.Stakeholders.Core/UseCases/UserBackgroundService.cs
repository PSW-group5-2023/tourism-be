using Explorer.Achievements.API.Internal;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        public UserBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CleanUpAccounts(stoppingToken);
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }

        private async Task CleanUpAccounts(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var inventoryMobileInternalService = scope.ServiceProvider.GetRequiredService<IInventoryMobileInternalService>();

                var usersQuery = await userRepository.GetAllGuestAsync();
                var usersToDelete = await usersQuery
                    .Where(u => (DateTime.UtcNow - u.GuestDateTimeCreated) >= TimeSpan.FromDays(14))
                    .ToListAsync(stoppingToken);

                if (usersToDelete.Any())
                {
                    await userRepository.DeleteGuestsAsync(usersToDelete, stoppingToken);
                }

                foreach (var user in usersToDelete)
                {
                    await Task.Run(() => inventoryMobileInternalService.DeleteByUserId(Convert.ToInt32(user.Id)), stoppingToken);
                }

            }
        }
    }
}
