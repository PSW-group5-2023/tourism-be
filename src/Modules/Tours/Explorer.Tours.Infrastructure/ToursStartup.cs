using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Mappers;
using Explorer.Tours.Infrastructure.Database;
using Explorer.Tours.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Core.UseCases.Execution;
using Explorer.Tours.API.Internal;
using Explorer.Tours.Infrastructure.Email;
using Explorer.Tours.Core.Domain.ServiceInterfaces;
using Explorer.Tours.API.Public.Equipment;
using Explorer.Tours.API.Public.Facility;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.API.Public.Problem;
using Explorer.Tours.API.Public.Rating;
using Explorer.Tours.Core.Domain.Equipment;
using Explorer.Tours.Core.Domain.Problem;
using Explorer.Tours.Core.Domain.Rating;
using Explorer.Tours.Core.Domain.Facilities;
using Explorer.Tours.Core.UseCases.Problem;
using Explorer.Tours.Core.UseCases.Rating;
using Explorer.Tours.Core.UseCases.Statistics;
using Explorer.Tours.Core.UseCases.Equipments;
using Explorer.Tours.Core.UseCases.Facilities;
using Explorer.Tours.Core.UseCases.Tours;
using Explorer.Tours.API.Public.Email;
using Explorer.Encounters.API.Internal;
using Explorer.Encounters.Core.UseCases;
using Explorer.Encounters.API.Public;

namespace Explorer.Tours.Infrastructure;

public static class ToursStartup
{
    public static IServiceCollection ConfigureToursModule(this IServiceCollection services)
    {
        // Registers all profiles since it works on the assembly
        services.AddAutoMapper(typeof(ToursProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }
    
    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<ITourService, TourService>();
        services.AddScoped<ICheckpointService, CheckpointService>();
        services.AddScoped<IPublicCheckpointService, PublicCheckpointsService>();
        services.AddScoped<IFacilityService, FacilityService>();
        services.AddScoped<ITourRatingService, TourRatingService>();
        services.AddScoped<ITourProblemService, TourProblemService>();
        services.AddScoped<IPreferencesService, PreferencesService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<IPositionSimulatorService, PositionSimulatorService>();
        services.AddScoped<IEquipmentTrackingService, EquipmentTrackingService>();
        services.AddScoped<IPublicFacilityService, PublicFacilityService>();
        services.AddScoped<IInternalTourService, TourService>();
        services.AddScoped<IRecommenderService, RecommenderService>();
        services.AddScoped<IEmailSendingTourCommunityRecommendationService, EmailSendingTourCommunityRecommendationService>();
        services.AddScoped<IInternalPersonService, InternalPersonService>();
        services.AddScoped<ITourStatisticsDomainService, TourStatisticsDomainService>();
        services.AddScoped<IInternalRecommenderService, RecommenderService>();
        services.AddScoped<IQuizAchievementMobileInternalService, QuizAchievementMobileInternalService>();

    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped<ICheckpointRepository, CheckpointDatabaseRepository>();
        services.AddScoped<IPublicCheckpointRepository, PublicCheckpointDatabaseRepository>();
        services.AddScoped<IFacilityRepository, FacilityRepository>();
        services.AddScoped(typeof(ICrudRepository<Equipment>), typeof(CrudDatabaseRepository<Equipment, ToursContext>));
        services.AddScoped(typeof(ITourRepository), typeof(TourDatabaseRepository));
        services.AddScoped(typeof(ICrudRepository<Checkpoint>), typeof(CrudDatabaseRepository<Checkpoint, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<PublicCheckpoint>), typeof(CrudDatabaseRepository<PublicCheckpoint, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<Facility>), typeof(CrudDatabaseRepository<Facility, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<TourRating>), typeof(CrudDatabaseRepository<TourRating, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<TourProblem>), typeof(CrudDatabaseRepository<TourProblem, ToursContext>));    
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped(typeof(IPositionSimulatorRepository), typeof(PositionSimulatorDatabaseRepository));
        services.AddScoped(typeof(ICrudRepository<PublicFacility>), typeof(CrudDatabaseRepository<PublicFacility, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<Preferences>), typeof(CrudDatabaseRepository<Preferences, ToursContext>));

        services.AddScoped<IPreferencesRepository, PreferencesRepository>();
        services.AddScoped<ITourProblemRepository, TourProblemRepository>();


        services.AddScoped(typeof(ICrudRepository<EquipmentTracking>), typeof(CrudDatabaseRepository<EquipmentTracking, ToursContext>));
        services.AddScoped<IEquipmentTrackingRepository, EquipmentTrackingRepository>();

        services.AddScoped<ITourRatingRepository, TourRatingRepository>();

        services.AddDbContext<ToursContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("tours"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "tours")));
    }
}