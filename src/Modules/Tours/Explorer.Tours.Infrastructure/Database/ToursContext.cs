using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Sessions;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database;

public class ToursContext : DbContext
{
    public DbSet<Tour> Tour { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<TourKeyPoint> TourKeyPoints { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<TourRating> TourRatings { get; set; }
    public DbSet<TourProblem> TourProblems { get; set; }
    public DbSet<Preferences> Preferences { get; set; }
    public DbSet<Session> Sessions { get; set; }

    public ToursContext(DbContextOptions<ToursContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tours");

        modelBuilder.Entity<Session>().Property(item => item.Location).HasColumnType("jsonb");

        ConfigureTour(modelBuilder);
    }

    private static void ConfigureTour(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Preferences>()
        //    .HasOne<User>()
        //    .WithOne()
        //    .HasForeignKey<Preferences>(s => s.UserId);

        modelBuilder.Entity<Session>()
            .HasOne<Tour>()
            .WithOne()
            .HasForeignKey<Session>(s => s.TourId);
    }
}