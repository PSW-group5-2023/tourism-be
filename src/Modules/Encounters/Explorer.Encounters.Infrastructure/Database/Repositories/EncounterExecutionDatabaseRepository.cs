using Explorer.BuildingBlocks.Core.UseCases;
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

        public PagedResult<EncounterExecution> GetAllActiveByEncounterId(long encounterId)
        {
            var task = _dbSet.Where(ee => ee.EncounterId == encounterId && ee.CompletionTime == null).GetPagedById(0, 0);
            task.Wait();
            return task.Result;
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
