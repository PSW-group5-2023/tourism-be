using Explorer.Achievements.Core.Domain;
using Explorer.Achievements.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Infrastructure.Database.Repositories
{
    public class AchievementRepository: IAchievementRepository
    {
        public readonly AchievementsContext _dbContext;
        private readonly DbSet<Achievement> _dbSet;

        public AchievementRepository(AchievementsContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Achievement>();
        }

        public Achievement GetAchievementByKeypointId(int keypointId)
        {
            var achievement = _dbSet.Where(achievement => achievement.KeypointId == keypointId).FirstOrDefault();
            return achievement;
        }
    }
}
