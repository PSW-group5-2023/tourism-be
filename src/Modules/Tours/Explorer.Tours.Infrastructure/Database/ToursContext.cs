using Explorer.Blog.Core.Domain;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
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
    public DbSet<EquipmentTracking> EquipmentTrackings { get; set; }
    public DbSet<PublicTourKeyPoints> PublicTourKeyPoints { get; set; }
    public DbSet<PublicFacility> PublicFacility { get; set; }


    public ToursContext(DbContextOptions<ToursContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tours");
        modelBuilder.Entity<TourProblem>().Property(item => item.Messages).HasColumnType("jsonb");

        modelBuilder.Entity<Session>().Property(item => item.Location).HasColumnType("jsonb");

        modelBuilder.Entity<Session>().Property(item => item.CompletedKeyPoints).HasColumnType("jsonb");

        ConfigureTour(modelBuilder);
    }

    private static void ConfigureTour(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>()
            .Property(t => t.Durations)
            .HasColumnType("jsonb");

        modelBuilder.Entity<Tour>()
            .HasMany(t => t.KeyPoints)
            .WithOne()
            .HasForeignKey(kp => kp.TourId);

        modelBuilder.Entity<Session>()
            .HasOne<Tour>()
            .WithMany()
            .HasForeignKey(s => s.TourId);
    }
}