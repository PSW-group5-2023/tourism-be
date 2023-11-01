using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Core.Domain.Sessions;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Execution
{
    public class SessionService : BaseService<SessionDto, Session>, ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionService( IMapper mapper, ISessionRepository sessionRepository) : base(mapper)
        {
            _sessionRepository = sessionRepository;
        }

        public Result<SessionDto> Create(SessionDto session)
        {
            return MapToDto(_sessionRepository.Create(MapToDomain(session)));
        }
    }
}
