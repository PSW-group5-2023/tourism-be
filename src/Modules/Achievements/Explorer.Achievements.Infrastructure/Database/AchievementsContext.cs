using Explorer.Achievements.Core.Domain;
using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Explorer.Achievements.Infrastructure.Database
{
    public class AchievementsContext : DbContext
    {
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Inventory> Inventory { get; set; }


        public AchievementsContext(DbContextOptions<AchievementsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("achievements");
            modelBuilder.Entity<Inventory>().Property(p => p.Achievements)
                     .HasColumnType("jsonb")
                     .HasConversion(
                       v => JsonSerializer.Serialize(v, new JsonSerializerOptions(JsonSerializerDefaults.General)),
                       v => JsonSerializer.Deserialize<Dictionary<int, int>>(v, new JsonSerializerOptions(JsonSerializerDefaults.General))!);
        }
    }
}
