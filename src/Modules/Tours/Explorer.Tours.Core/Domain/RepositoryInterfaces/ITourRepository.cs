using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourRepository : ICrudRepository<Tour>
    {
        public PagedResult<Tour> GetPagedByIds(List<int> ids, int page, int pageSize);
        public void SaveChanges();
        public PagedResult<Tour> GetPagedByAuthorId(int authorId, int page, int pageSize);
        public List<Tour> GetAllByAuthorId(int authorId);
    }
}
