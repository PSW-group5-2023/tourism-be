using Explorer.Blog.Core.Domain;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain;
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
    public DbSet<PositionSimulator> PositionSimulators { get; set; }
    public DbSet<Preferences> Preferences { get; set; }

    public ToursContext(DbContextOptions<ToursContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tours");
        //modelBuilder.Entity<TourProblem>().Property(item => item.Messages).HasColumnType("jsonb");

        //modelBuilder.Entity<Preferences>()
        //    .HasOne<User>()
        //    .WithOne()
        //    .HasForeignKey<Preferences>(s => s.UserId);
    }
}