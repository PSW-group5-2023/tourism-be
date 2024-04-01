using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Sessions;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class PositionSimulatorDatabaseRepository : CrudDatabaseRepository<PositionSimulator, ToursContext>, IPositionSimulatorRepository
    {
        private readonly DbSet<PositionSimulator> _dbSet;
        public PositionSimulatorDatabaseRepository(ToursContext dbContext) : base(dbContext)
        {
            _dbSet = DbContext.Set<PositionSimulator>();
        }

        public PositionSimulator GetByTouristId(long touristId)
        {
            return _dbSet.Where(ps => ps.TouristId == touristId).FirstOrDefault() ?? throw new KeyNotFoundException($"Tourist with id={touristId} does not have existing position");
        }
    }
}
