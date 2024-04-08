using Explorer.Encounters.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Encounters.Infrastructure.Database
{
    public class EncountersContext : DbContext
    {
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeExecution> ChallengeExecutions { get; set; }
        public DbSet<UserExperience> UserExperience { get; set; }

        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<SocialEncounter> SocialEncounters { get; set; }
        public DbSet<LocationEncounter> LocationEncounters { get; set; }
        public EncountersContext(DbContextOptions<EncountersContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("encounters");

            modelBuilder.Entity<ChallengeExecution>()
                .HasOne(item => item.Challenge)
                .WithMany()
                .HasForeignKey("ChallengeId");
            ConfigureEncounters(modelBuilder);
            ConfigureEncounterExecutions(modelBuilder);
            ConfigureUserExperience(modelBuilder);
        }

        private void ConfigureUserExperience(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserExperience>()
                            .HasIndex(ue => ue.UserId)
                            .IsUnique();
        }

        private void ConfigureEncounterExecutions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EncounterExecution>()
                            .HasIndex(ee => new { ee.TouristId, ee.EncounterId })
                            .IsUnique();
        }

        private void ConfigureEncounters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Encounter>()
                            .HasDiscriminator(e => e.Type)
                            .HasValue<Encounter>(EncounterType.Misc)
                            .HasValue<SocialEncounter>(EncounterType.Social)
                            .HasValue<LocationEncounter>(EncounterType.Location);

            modelBuilder.Entity<Encounter>()
                .HasMany<EncounterExecution>()
                .WithOne();

            modelBuilder.Entity<Encounter>()
                .HasIndex(e => e.KeyPointId)
                .HasFilter("\"KeyPointId\" is not null");
        }
    }
}
