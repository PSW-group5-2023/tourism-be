using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly StakeholdersContext _dbContext;

        public UserProfileRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserProfile GetById(int id)
        {
            return _dbContext.UserProfiles.FirstOrDefault(u => u.UserId == id);
        }

        public UserProfile Update(UserProfile userProfile, int id)
        {
            //userProfile.Id = id;

            UserProfile updated = _dbContext.UserProfiles.Update(userProfile).Entity;
            _dbContext.SaveChanges();
            return updated;
        }
    }
}
