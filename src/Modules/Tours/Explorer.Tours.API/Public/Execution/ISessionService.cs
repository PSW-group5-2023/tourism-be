using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Execution
{
    public interface ISessionService
    {
        Result<SessionDto> Create(SessionDto session);
        Result<SessionDto> Update(SessionDto session);
        Result<SessionDto> Get(long id);
        Result<SessionDto> GetByTouristId(long id);
    }
}
