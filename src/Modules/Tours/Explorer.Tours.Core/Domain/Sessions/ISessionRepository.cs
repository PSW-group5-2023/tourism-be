using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.Sessions
{
    public interface ISessionRepository
    {
        Session Create(Session session);
        Session Update(Session session);
        Session Get(long id);
        Session? GetByTouristId(long id);
        Session AddCompletedKeyPoint(int sessionId, int keyPointId);
    }
}
