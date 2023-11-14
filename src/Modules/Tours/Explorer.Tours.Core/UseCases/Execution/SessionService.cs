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

        public Result<SessionDto> Get(long id)
        {
            try
            {
                var result = _sessionRepository.Get(id);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<SessionDto> GetByTouristId(long id)
        {
            var result = _sessionRepository.GetByTouristId(id);
            return MapToDto(result);
        }

        public Result<SessionDto> Update(SessionDto session)
        {
            try
            {
                var result = _sessionRepository.Update(MapToDomain(session));
                return MapToDto(result);
            }
            catch(KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch(ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<bool> ValidForTouristComment(long id)
        {
            var result = _sessionRepository.Get(id);
            return result.ValidForTouristComment();
        }

        public Result<SessionDto> AddCompletedKeyPoint(int sessionId, int keyPointId)
        {
            var result = _sessionRepository.AddCompletedKeyPoint(sessionId, keyPointId);

            return MapToDto(result);
        }
    }
}
