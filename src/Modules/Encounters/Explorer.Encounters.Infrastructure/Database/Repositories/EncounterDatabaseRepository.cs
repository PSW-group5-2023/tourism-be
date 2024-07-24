using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

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

        public PagedResult<Encounter> GetPagedByCheckpointIds(List<long> checkpointIds, int page, int pageSize)
        {
            var task = _dbSet
                .Where(ee => ee.CheckpointId.HasValue && checkpointIds.Contains(ee.CheckpointId.Value))
                .Include(e => (e as QuizEncounter).Questions)
                .GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public PagedResult<Encounter> GetPaged(int page, int pageSize)
        {
            var task = _dbSet
                .Include(e => (e as QuizEncounter).Questions)
                .GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public Encounter Get(long id)
        {
            var quizEncounter = _dbSet
                .Where(e => e.Id == id)
                .Include(e => (e as QuizEncounter).Questions)
                .FirstOrDefault();

            if (quizEncounter == null)
            {
                throw new KeyNotFoundException($"QuizEncounter not found for id: {id}");
            }

            return quizEncounter;
        }

        public PagedResult<Encounter> GetPublicPaged(int page, int pageSize)
        {
            var task = _dbSet
                .Where(ee => ee.CheckpointId == null) // Nisam dodao za Questions jer Quiz ide samo na checkpoint!
                .GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public Encounter GetByCheckpointId(int checkpointId)
        {
            return _dbSet.Where(x=>x.CheckpointId == checkpointId).First();
        }
    }
}
