using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Encounters.API.Internal;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Explorer.Encounters.Core.Mappers;
using Explorer.Encounters.Core.UseCases;
using Explorer.Encounters.Infrastructure.Database;
using Explorer.Encounters.Infrastructure.Database.Repositories;
using Explorer.Tours.API.Internal;
using Explorer.Tours.Core.UseCases.Tours;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Infrastructure
{
    public static class EncountersStartup
    {
        public static IServiceCollection ConfigureEncountersModule(this IServiceCollection services)
        {
            // Registers all profiles since it works on the assembly
            services.AddAutoMapper(typeof(EncounterProfile).Assembly);
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IUserExperienceService, UserExperienceService>();
            services.AddScoped<IUserXP, UserXPService>();
            services.AddScoped<IEncounterService, EncounterService>();
            services.AddScoped<IEncounterExecutionService, EncounterExecutionService>();
            services.AddScoped<IInternalCheckpointService, InternalCheckpointService>();
            services.AddScoped<IQuestionService, QuestionService>();
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<UserExperience>), typeof(CrudDatabaseRepository<UserExperience, EncountersContext>));
            services.AddScoped(typeof(IUserExperienceRepository), typeof(UserExperienceDatabaseRepository));
            services.AddScoped(typeof(IEncounterRepository), typeof(EncounterDatabaseRepository));
            services.AddScoped(typeof(IEncounterExecutionRepository), typeof(EncounterExecutionDatabaseRepository));
            services.AddScoped(typeof(IQuestionRepository), typeof(QuestionDatabaseRepository));

            services.AddDbContext<EncountersContext>(opt =>
                opt.UseNpgsql(DbConnectionStringBuilder.Build("encounters"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "encounters")));
        }
    }
}
