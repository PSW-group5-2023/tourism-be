using Explorer.Achievements.Core.Domain;
using Explorer.Achievements.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
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

        public Achievement Get(int id)
        {
            return _dbSet.Where(x=>x.Id==id).First();
        }

        public List<Achievement> GetAllBaseAchievements()
        {
            return _dbSet.Where(a => a.CraftingRecipe.Count == 0).ToList();
        }

        public List<Achievement> GetAllComplexAchievements()
        {
            return _dbSet.Where(a => a.CraftingRecipe.Count != 0).ToList();
        }
    }
}
