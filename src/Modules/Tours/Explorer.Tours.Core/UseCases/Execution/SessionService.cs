﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Dtos.Execution.Tourist;
using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.ServiceInterfaces;
using Explorer.Tours.Core.Domain.Sessions;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Execution
{
    public class SessionService : BaseService<SessionDto, Session>, ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ITourStatisticsDomainService _tourStatisticsDomainService;
        private readonly ITourService _tourService;
        private readonly IMapper _mapper;
        public SessionService( IMapper mapper, ISessionRepository sessionRepository, ITourStatisticsDomainService tourStatisticsDomainService, ITourService tourService) : base(mapper)
        {
            _sessionRepository = sessionRepository;
            _tourStatisticsDomainService = tourStatisticsDomainService;
            _tourService = tourService;
            _mapper = mapper;
        }

        public Result<SessionDto> Create(SessionDto session)
        {
            var result = _sessionRepository.Create(MapToDomain(session));
            result.Create();
            _sessionRepository.SaveChanges();

            return MapToDto(result);
        }

        public Result<SessionMobileDto> CreateMobile(SessionMobileDto session)
        {
            var sessionDomain = _mapper.Map<Session>(session);
            var result = _sessionRepository.Create(sessionDomain);
            result.Create();
            _sessionRepository.SaveChanges();

            return Result.Ok(_mapper.Map<SessionMobileDto>(result));
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

        public Result<SessionDto> GetActiveByTouristId(long id)
        {
            var result = _sessionRepository.GetActiveByTouristId(id);
            return MapToDto(result);
        }

        public Result<List<SessionDto>> GetAllByTouristId(long id)
        {
            var result = _sessionRepository.GetAllByTouristId(id);
            return MapToDto(result);
        }
        public Result<SessionDto> GetActiveSessionByTouristId(long id)
        {
            var result = _sessionRepository.GetActiveSessionByTouristId(id);
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

        public Result<SessionMobileDto> UpdateMobile(SessionMobileDto session)
        {
            try
            {
                var sessionDomain = _mapper.Map<Session>(session);
                var result = _sessionRepository.Update(sessionDomain);

                return Result.Ok(_mapper.Map<SessionMobileDto>(result));
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch (ArgumentException e)
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

            var domainStatistics = _tourStatisticsDomainService.CalculateAttendanceStatistics(sessions);

            var attendanceStatistics = new List<TourStatisticsDto>();

            foreach(var stat in domainStatistics)
            {
                TourStatisticsDto statDto = new TourStatisticsDto();
                statDto.TourId = stat.TourId;
                statDto.NumberOfStats = stat.NumberOfStats;
                attendanceStatistics.Add(statDto);
            }

            return attendanceStatistics;
        }

        public Result<List<TourStatisticsDto>> GetAbandonedStatistics()
        {
            var sessions = _sessionRepository.GetAll();

            var domainStatistics = _tourStatisticsDomainService.CalculateAbandonedStatistics(sessions);

            var abandonedStatistics = new List<TourStatisticsDto>();

            foreach (var stat in domainStatistics)
            {
                TourStatisticsDto statDto = new TourStatisticsDto();
                statDto.TourId = stat.TourId;
                statDto.NumberOfStats = stat.NumberOfStats;
                abandonedStatistics.Add(statDto);
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

        public Result<int> GetNumberOfStartedTours(int authorId)
        {
            var sessions = _sessionRepository.GetAll();
            var authorsTours = _tourService.GetAllByAuthorId(authorId);
            var tourIds = new List<long>();
            foreach(var tour in authorsTours)
            {
                tourIds.Add(tour.Id);
            }

            return _tourStatisticsDomainService.CalculateNumberOfStartedTours(sessions, tourIds);
        }

        public Result<int> GetNumberOfCompletedTours(int authorId)
        {
            var sessions = _sessionRepository.GetAll();
            var authorsTours = _tourService.GetAllByAuthorId(authorId);
            var tourIds = new List<long>();
            foreach (var tour in authorsTours)
            {
                tourIds.Add(tour.Id);
            }

            return _tourStatisticsDomainService.CalculateNumberOfCompletedTours(sessions, tourIds);
        }

        public Result<List<int>> GetTourCompletionPercentageStats(int authorId)
        {
            var sessions = _sessionRepository.GetAll();
            var authorsTours = _tourService.GetAllByAuthorId(authorId);
            var tourIds = new List<long>();
            foreach (var tour in authorsTours)
            {
                tourIds.Add(tour.Id);
            }

            return _tourStatisticsDomainService.CalculateTourCompletionPercentage(sessions, tourIds);
        }

        public Result<PagedResult<SessionDto>> GetPagedByTouristId(long touristId, int page, int pageSize)
        {
            var result = _sessionRepository.GetPagedByTouristId(touristId, page, pageSize);
            return MapToDto(result);
        }
    }
}
