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

    public DbSet<EquipmentTracking> EquipmentTrackings { get; set; }

    public DbSet<PublicTourKeyPoints> PublicTourKeyPoints { get; set; }
    public DbSet<PublicFacility> PublicFacility { get; set; }
    public DbSet<BoughtItem> BoughtItems { get; set; }


    public ToursContext(DbContextOptions<ToursContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tours");

  /*      modelBuilder.Entity<BoughtItem>()
            .HasOne(item => item.Tour)
            .WithMany()
            .HasForeignKey(item => item.TourId); */



        //modelBuilder.Entity<Preferences>()
        //    .HasOne<User>()
        //    .WithOne()
        //    .HasForeignKey<Preferences>(s => s.UserId);
    }
}