using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourRepository : ICrudRepository<Tour>
    {
        public void SaveChanges();
        public PagedResult<Tour> GetPagedByAuthorId(int authorId, int page, int pageSize);
    }
}
