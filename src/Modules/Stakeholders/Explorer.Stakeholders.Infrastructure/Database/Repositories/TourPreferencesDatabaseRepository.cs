using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class TourPreferencesDatabaseRepository : ITourPreferencesRepository
    {
        private readonly StakeholdersContext _dbContext;
        public TourPreferencesDatabaseRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TourPreferences? GetByUserId(long userId)
        {
            return _dbContext.TourPreferences.FirstOrDefault(p => p.UserId == userId);
        }
    }
}
