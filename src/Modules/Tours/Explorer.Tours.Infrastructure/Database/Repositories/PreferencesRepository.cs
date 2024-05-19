using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class PreferencesRepository : IPreferencesRepository
    {
        private readonly ToursContext _dbContext;
        public PreferencesRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Preferences? GetByUserId(long userId)
        {
            return _dbContext.Preferences.FirstOrDefault(p => p.UserId == userId);
        }
    }
}
