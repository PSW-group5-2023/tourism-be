using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class CheckpointDatabaseRepository : ICheckpointRepository
    {
        private readonly ToursContext _dbContext;
        
        public CheckpointDatabaseRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Checkpoint> GetByTourId(long tourId)
        {
            var checkpoints = _dbContext.Checkpoints.Where(x => x.TourId == tourId).ToList();
            return checkpoints;
        }
        public Checkpoint GetById(int id)
        {
            var checkpoint = _dbContext.Checkpoints.FirstOrDefault(x => x.Id == id);
            return checkpoint;
        }

        public Checkpoint Update(Checkpoint newCheckpoint)
        {
            var checkpoint = _dbContext.Checkpoints.FirstOrDefault(x => x.Id == newCheckpoint.Id);
            checkpoint = newCheckpoint;
            _dbContext.SaveChanges();
            return checkpoint;
        }

        public Checkpoint Get(long id)
        {
            var checkpoint = _dbContext.Checkpoints.FirstOrDefault(c => c.Id == id);
            return checkpoint;
        }
    }
}
