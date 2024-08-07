using Explorer.Encounters.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Encounters.Infrastructure.Database
{
    public class EncountersContext : DbContext
    {
        public DbSet<UserExperience> UserExperience { get; set; }

        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<SocialEncounter> SocialEncounters { get; set; }
        public DbSet<LocationEncounter> LocationEncounters { get; set; }
        public DbSet<EncounterExecution> EncounterExecutions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public EncountersContext(DbContextOptions<EncountersContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("encounters");

            ConfigureEncounters(modelBuilder);
            ConfigureEncounterExecutions(modelBuilder);
            ConfigureUserExperience(modelBuilder);
            ConfigureQuestions(modelBuilder);
        }

        private void ConfigureQuestions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
            .Property(t => t.Answers)
            .HasColumnType("jsonb");
        }

        private void ConfigureUserExperience(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserExperience>()
                            .HasIndex(ue => ue.UserId)
                            .IsUnique();
        }

        private void ConfigureEncounterExecutions(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EncounterExecution>()
            //                .HasIndex(ee => new { ee.TouristId, ee.EncounterId })
            //                .IsUnique();

            modelBuilder.Entity<EncounterExecution>()
                            .Property(e => e.Answers)
                            .HasColumnType("jsonb");
        }

        private void ConfigureEncounters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Encounter>()
                            .HasDiscriminator(e => e.Type)
                            .HasValue<Encounter>(EncounterType.Misc)
                            .HasValue<SocialEncounter>(EncounterType.Social)
                            .HasValue<LocationEncounter>(EncounterType.Location)
                            .HasValue<QuizEncounter>(EncounterType.Quiz);

            modelBuilder.Entity<Encounter>()
                .HasMany<EncounterExecution>()
                .WithOne();

            modelBuilder.Entity<Encounter>()
                .HasIndex(e => e.CheckpointId)
                .HasFilter("\"CheckpointId\" is not null");

            modelBuilder.Entity<QuizEncounter>()
                .HasMany(qe => qe.Questions)
                .WithOne()
                .HasForeignKey("EncounterId")
                .IsRequired();
        }
    }
}
