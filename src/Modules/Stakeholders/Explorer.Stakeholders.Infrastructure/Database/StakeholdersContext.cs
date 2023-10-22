﻿using Explorer.Stakeholders.Core;
using Explorer.Stakeholders.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Stakeholders.Infrastructure.Database;

public class StakeholdersContext : DbContext
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<TourPreferences> TourPreferences { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<JoinRequest> JoinRequests { get; set; }

    public StakeholdersContext(DbContextOptions<StakeholdersContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("stakeholders");

        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

        ConfigureStakeholder(modelBuilder); 
    }

    private static void ConfigureStakeholder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<Person>(s => s.UserId);


        modelBuilder.Entity<TourPreferences>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<TourPreferences>(s => s.UserId);

        modelBuilder.Entity<Club>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<Club>(s => s.TouristId);

        modelBuilder.Entity<JoinRequest>()
        .HasOne<User>()
        .WithMany()
        .HasForeignKey(jr => jr.UserId);

        modelBuilder.Entity<JoinRequest>()
            .HasOne<Club>()
            .WithMany()
            .HasForeignKey(jr => jr.ClubId);
    }
}