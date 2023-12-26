using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Sessions;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class InternalPositionSimulatorRepository : IInternalPositionSimulatorRepository
    {
        private readonly ToursContext _dbContext;
        private readonly DbSet<PositionSimulator> _dbSet;
        public InternalPositionSimulatorRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<PositionSimulator>();
        }
        public PositionSimulator GetByTouristId(long touristId)
        {
            return _dbSet.Where(ps => ps.TouristId == touristId).FirstOrDefault() ?? throw new KeyNotFoundException($"Tourist with id={touristId} does not have existing position");
        }
    }
}
