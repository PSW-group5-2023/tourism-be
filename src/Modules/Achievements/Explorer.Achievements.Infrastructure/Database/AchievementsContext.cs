using Explorer.Achievements.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
    }
}
