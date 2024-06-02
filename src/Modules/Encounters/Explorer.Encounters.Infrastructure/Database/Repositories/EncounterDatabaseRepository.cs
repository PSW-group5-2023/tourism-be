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
                .GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public QuizEncounter GetQuizEncounter(long encounterId)
        {
            var quizEncounter = _dbSet
                .Where(e => e.Id == encounterId)
                .OfType<QuizEncounter>() // Filtrira samo QuizEncounter
                .Include(qe => qe.Questions) // Učitava pitanja povezana s QuizEncounter
                .FirstOrDefault();

            if (quizEncounter == null)
            {
                throw new KeyNotFoundException($"QuizEncounter not found for id: {encounterId}");
            }

            return quizEncounter;
        }

        public PagedResult<Encounter> GetPublicPaged(int page, int pageSize)
        {
            var task = _dbSet
                .Where(ee => ee.CheckpointId == null)
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
