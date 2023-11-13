using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourRepository : ICrudRepository<Tour>
    {
        public Tour GetWithKeyPoints(int id);
        public void SaveChanges();
    }
}
