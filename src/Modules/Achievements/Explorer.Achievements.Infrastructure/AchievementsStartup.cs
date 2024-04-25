using Explorer.Achievements.API.Public;
using Explorer.Achievements.Core.Domain;
using Explorer.Achievements.Core.Mappers;
using Explorer.Achievements.Core.UseCases;
using Explorer.Achievements.Infrastructure.Database;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IAchievementService, AchievementService>();
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<Achievement>), typeof(CrudDatabaseRepository<Achievement, AchievementsContext>));
            services.AddDbContext<AchievementsContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("achievements"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "achievements")));
        }
    }
}
