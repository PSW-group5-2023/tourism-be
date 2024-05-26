using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ICheckpointRepository
    {
        List<Checkpoint> GetByTourId(long tourId); 
        Checkpoint GetById(int id);
        Checkpoint Update(Checkpoint keyPoint);
        Checkpoint Get(long id);
    }
}
