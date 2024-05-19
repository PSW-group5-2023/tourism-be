using Explorer.Achievements.Infrastructure.Database;
using Explorer.BuildingBlocks.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Tests
{
    public class AchievementsTestFactory : BaseTestFactory<AchievementsContext>
    {
        protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AchievementsContext>));
            services.Remove(descriptor!);
            services.AddDbContext<AchievementsContext>(SetupTestContext());
 
            return services;
        }
    }
}
