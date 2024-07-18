using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Encounters.Infrastructure.Database.Repositories
{
    public class UserExperienceDatabaseRepository : CrudDatabaseRepository<UserExperience, EncountersContext>, IUserExperienceRepository
    {
        private readonly DbSet<UserExperience> _dbSet;
        public UserExperienceDatabaseRepository(EncountersContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<UserExperience>();
        }

        public UserExperience GetByUserId(long userId)
        {
            var userExperience = _dbSet.Where(u => u.UserId == userId).FirstOrDefault();
            if (userExperience != null) return userExperience;
            UserExperience newItem = new(userId, 0);
            return Create(newItem);
        }
    }
}
