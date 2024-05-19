using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Explorer.Encounters.Infrastructure.Database.Repositories
{
    public class EncounterDatabaseRepository : CrudDatabaseRepository<Encounter, EncountersContext>, IEncounterRepository
    {
        private readonly DbSet<Encounter> _dbSet;
        public EncounterDatabaseRepository(EncountersContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Encounter>();
        }

        public Encounter GetNoTracking(long id)
        {
            var entity = _dbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);
            return entity ?? throw new KeyNotFoundException("Not found: " + id);
        }

        public PagedResult<Encounter> GetPagedByKeyPointIds(List<long> keyPointIds, int page, int pageSize)
        {
            var task = _dbSet
                .Where(ee => ee.KeyPointId.HasValue && keyPointIds.Contains(ee.KeyPointId.Value))
                .GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public PagedResult<Encounter> GetPublicPaged(int page, int pageSize)
        {
            var task = _dbSet
                .Where(ee => ee.KeyPointId == null)
                .GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
