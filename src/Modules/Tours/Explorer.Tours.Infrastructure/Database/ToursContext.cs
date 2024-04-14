﻿using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.Sessions;
using Microsoft.EntityFrameworkCore;
using Explorer.Tours.Core.Domain.Sessions.DomainEvents;
using Explorer.Tours.Core.Domain.Equipment;
using Explorer.Tours.Core.Domain.Problem;
using Explorer.Tours.Core.Domain.Rating;
using Explorer.Tours.Core.Domain.Facilities;

namespace Explorer.Tours.Infrastructure.Database;

public class ToursContext : DbContext
{
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Checkpoint> Checkpoints { get; set; }
    public DbSet<PublicCheckpoint> PublicCheckpoints { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<TourRating> TourRatings { get; set; }
    public DbSet<TourProblem> TourProblems { get; set; }
    public DbSet<Preferences> Preferences { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<PositionSimulator> PositionSimulators { get; set; }
    public DbSet<EquipmentTracking> EquipmentTrackings { get; set; }
    public DbSet<PublicFacility> PublicFacility { get; set; }


    public ToursContext(DbContextOptions<ToursContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tours");
        modelBuilder.Entity<TourProblem>().Property(item => item.Messages).HasColumnType("jsonb");

        modelBuilder.Entity<Session>().Property(item => item.CompletedKeyPoints).HasColumnType("jsonb");

        modelBuilder.Entity<PositionSimulator>()
            .HasIndex(ps => ps.TouristId)
            .IsUnique();

        ConfigureTour(modelBuilder);
    }

    private static void ConfigureTour(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Tour>()
            .HasMany(t => t.Checkpoints)
            .WithOne()
            .HasForeignKey(cp => cp.TourId);

        modelBuilder.Entity<Session>()
            .HasOne<Tour>()
            .WithMany()
            .HasForeignKey(s => s.TourId);

        modelBuilder.Entity<Session>()
            .HasOne<PositionSimulator>()
            .WithMany()
            .HasForeignKey(s => s.LocationId);

        modelBuilder.Entity<DomainEvent>()
                .HasDiscriminator<string>("EventType")
                .HasValue<KeyPointCompleted>("KeyPointUpdated")
                .HasValue<LocationUpdated>("LocationUpdated")
                .HasValue<SessionCreated>("SessionCreated");
    }
}