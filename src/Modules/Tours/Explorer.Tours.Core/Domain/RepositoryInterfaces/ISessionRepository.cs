using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain.Sessions;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ISessionRepository
    {
        Session Create(Session session);
        Session Update(Session session);
        Session? Get(long id);
        Session? GetActiveByTouristId(long id);
        List<Session> GetAllByTouristId(long id);
        Session? GetActiveSessionByTouristId(long id);
        Session AddCompletedKeyPoint(int sessionId, int keyPointId);
        Session? GetByTourAndTouristId(long tourId, long touristId);
        List<Session> GetAll();
        PagedResult<Session> GetPagedByTouristId(long touristId, int page, int pageSize);
        public void SaveChanges();
    }
}
