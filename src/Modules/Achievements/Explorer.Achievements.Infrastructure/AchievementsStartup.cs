using Explorer.Achievements.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Infrastructure
{
    public static class AchievementsStartup
    {

        public static IServiceCollection ConfigureAchievementsModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AchievementsProfile).Assembly);
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
        }
    }
}
