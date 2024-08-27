using Explorer.Achievements.Core.Domain;
using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            var comparer = new ValueComparer<Dictionary<int, int>>(
                                    (c1, c2) => c1.SequenceEqual(c2),
                                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.Key.GetHashCode(), v.Value.GetHashCode())),
                                    c => c.ToDictionary(entry => entry.Key, entry => entry.Value)
                                );
            modelBuilder.HasDefaultSchema("achievements");
            modelBuilder.Entity<Inventory>().Property(p => p.Achievements)
                     .HasColumnType("jsonb")
                     .HasConversion(
                       v => JsonSerializer.Serialize(v, new JsonSerializerOptions(JsonSerializerDefaults.General)),
                       v => JsonSerializer.Deserialize<Dictionary<int, int>>(v, new JsonSerializerOptions(JsonSerializerDefaults.General))!
                       ).Metadata.SetValueComparer(comparer); 
        }
    }
}
