using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Mappers;
using Explorer.Tours.Core.UseCases;
using Explorer.Tours.Core.UseCases.Administration;
using Explorer.Tours.Infrastructure.Database;
using Explorer.Tours.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Explorer.Stakeholders.Core.UseCases;

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
        services.AddScoped<ITourKeyPointService, TourKeyPointService>();
        services.AddScoped<IFacilityService, FacilityService>();
        services.AddScoped<ITourRatingService, TourRatingService>();
        services.AddScoped<ITourProblemService, TourProblemService>();
        services.AddScoped<IPositionSimulatorService, PositionSimulatorService>();
        services.AddScoped<IPreferencesService, PreferencesService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped<ITourKeyPointsRepository, TourKeyPointsRepository>();
        services.AddScoped(typeof(ICrudRepository<Equipment>), typeof(CrudDatabaseRepository<Equipment, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<Tour>), typeof(CrudDatabaseRepository<Tour, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<TourKeyPoint>), typeof(CrudDatabaseRepository<TourKeyPoint, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<Facility>), typeof(CrudDatabaseRepository<Facility, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<TourRating>), typeof(CrudDatabaseRepository<TourRating, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<TourProblem>), typeof(CrudDatabaseRepository<TourProblem, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<PositionSimulator>), typeof(CrudDatabaseRepository<PositionSimulator, ToursContext>));

        services.AddScoped(typeof(ICrudRepository<Preferences>), typeof(CrudDatabaseRepository<Preferences, ToursContext>));
        services.AddScoped<IPreferencesRepository, PreferencesRepository>();
        services.AddDbContext<ToursContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("tours"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "tours")));
    }
}