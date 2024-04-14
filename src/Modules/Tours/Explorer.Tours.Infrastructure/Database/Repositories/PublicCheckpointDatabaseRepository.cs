using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class PublicCheckpointDatabaseRepository : IPublicCheckpointRepository
    {
        private readonly ToursContext _dbContext;

        public PublicCheckpointDatabaseRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PublicCheckpoint GetById(long id)
        {
            var checkpoint = _dbContext.PublicCheckpoints.FirstOrDefault(x => x.Id == id);
            return checkpoint;
        }

        public PublicCheckpoint Update(PublicCheckpoint newCheckpoint)
        {
            var checkpoint = _dbContext.PublicCheckpoints.FirstOrDefault(x => x.Id == newCheckpoint.Id);
            checkpoint = newCheckpoint;
            _dbContext.SaveChanges();
            return checkpoint;
        }

        public List<PublicCheckpoint> GetByStatus(PublicCheckpointStatus status)
        {
            var checkpoints = _dbContext.PublicCheckpoints.Where(x => x.Status == status).ToList();
            return checkpoints;
        }

    }
}
