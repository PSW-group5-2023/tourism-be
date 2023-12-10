using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain.Sessions;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ISessionRepository
    {
        Session Create(Session session);
        Session Update(Session session);
        Session Get(long id);
        Session? GetByTouristId(long id);
        Session AddCompletedKeyPoint(int sessionId, int keyPointId);
        Session? GetByTourAndTouristId(long tourId, long touristId);
        List<Session> GetAll();
    }
}
