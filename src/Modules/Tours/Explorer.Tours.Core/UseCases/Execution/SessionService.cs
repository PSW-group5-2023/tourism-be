using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.ServiceInterfaces;
using Explorer.Tours.Core.Domain.Sessions;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Execution
{
    public class SessionService : BaseService<SessionDto, Session>, ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ITourStatisticsDomainService _tourStatisticsDomainService;
        public SessionService( IMapper mapper, ISessionRepository sessionRepository, ITourStatisticsDomainService tourStatisticsDomainService) : base(mapper)
        {
            _sessionRepository = sessionRepository;
            _tourStatisticsDomainService = tourStatisticsDomainService;
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
            if(result != null)
            {
                return result.ValidForTouristComment();
            }
            return Result.Fail(FailureCode.NotFound);          
        }

        public Result<SessionDto> AddCompletedKeyPoint(int sessionId, int keyPointId)
        {
            var result = _sessionRepository.AddCompletedKeyPoint(sessionId, keyPointId);

            return MapToDto(result);
        }
        public Result<SessionDto> GetByTourAndTouristId(long tourId, long touristId)
        {
            var result = _sessionRepository.GetByTourAndTouristId(tourId,touristId);
            return MapToDto(result);
        }


        public Result<List<TourStatisticsDto>> GetAttendanceStatistics()
        {
            var sessions = _sessionRepository.GetAll();
            var attendanceStatistics = new List<TourStatisticsDto>();

            foreach (var session in sessions)
            {
                var matchingStat = attendanceStatistics.FirstOrDefault(stat => stat.TourId == session.TourId);

                
                if (session.SessionStatus == SessionStatus.ACTIVE || session.SessionStatus == SessionStatus.COMPLETED)
                {
                    if (matchingStat != null)
                    {
                        matchingStat.NumberOfStats += 1;
                    }
                    else
                    {
                        TourStatisticsDto stat = new TourStatisticsDto();
                        stat.TourId = session.TourId;
                        stat.NumberOfStats = 1;
                        attendanceStatistics.Add(stat);
                    }
                }
            }

            return attendanceStatistics;
        }

        public Result<List<TourStatisticsDto>> GetAbandonedStatistics()
        {
            var sessions = _sessionRepository.GetAll();
            var abandonedStatistics = new List<TourStatisticsDto>();

            foreach (var session in sessions)
            {
                var matchingStat = abandonedStatistics.FirstOrDefault(stat => stat.TourId == session.TourId);

                if(session.SessionStatus == SessionStatus.ABANDONED)
                {
                    if (matchingStat != null)
                    {
                        matchingStat.NumberOfStats += 1;
                    }
                    else
                    {
                        TourStatisticsDto stat = new TourStatisticsDto();
                        stat.TourId = session.TourId;
                        stat.NumberOfStats = 1;
                        abandonedStatistics.Add(stat);
                    }
                }
            }

            return abandonedStatistics;
        }

        public Result<TourStatisticsDto> GetSessionsByStatusForTourStatistics(int tourId, int sessionStatus)
        {
            var sessions = _sessionRepository.GetAll();
            var result = _tourStatisticsDomainService.GetSessionsByStatusForTourStatistics(tourId,sessionStatus,sessions);
            TourStatisticsDto stat = new TourStatisticsDto();
            stat.TourId = result.Value.TourId;
            stat.NumberOfStats = result.Value.NumberOfStats;
            return stat;
        }

        public Result<TourStatisticsDto> GetNumberSessionsByTour(int tourId)
        {
            var sessions = _sessionRepository.GetAll();
            var result = _tourStatisticsDomainService.GetNumberSessionsByTour(tourId, sessions);
            TourStatisticsDto stat = new TourStatisticsDto();
            stat.TourId = result.Value.TourId;
            stat.NumberOfStats = result.Value.NumberOfStats;
            return stat;
        }

        public Result<TourStatisticsDto> GetStatisticsForCompletedKeypointOnTour(int tourId, int keyPointId)
        {
            var sessions = _sessionRepository.GetAll();
            var result = _tourStatisticsDomainService.GetStatisticsForCompletedKeypointOnTour(tourId, keyPointId, sessions);
            TourStatisticsDto stat = new TourStatisticsDto();
            stat.TourId = result.Value.TourId;
            stat.NumberOfStats = result.Value.NumberOfStats;
            return stat;
        }
    }
}
