using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Encounters.Infrastructure.Database.Repositories
{
    public class EncounterExecutionDatabaseRepository : CrudDatabaseRepository<EncounterExecution, EncountersContext>, IEncounterExecutionRepository
    {
        private readonly DbSet<EncounterExecution> _dbSet;
        public EncounterExecutionDatabaseRepository(EncountersContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<EncounterExecution>();
        }

        public EncounterExecution GetByTouristIdAndEncounterId(long touristId, long encounterId)
        {
            var encounterExecution = _dbSet.FirstOrDefault(ee => ee.TouristId == touristId && ee.EncounterId == encounterId);
            return encounterExecution ?? throw new KeyNotFoundException("Encounter execution doesn't exist");
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
