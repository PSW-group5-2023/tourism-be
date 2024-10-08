﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Rating;
using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Rating;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.Rating;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.ServiceInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;


namespace Explorer.Tours.Core.UseCases.Rating
{
    public class TourRatingService : CrudService<TourRatingDto, TourRating>, ITourRatingService
    {
        private readonly ITourRatingRepository _tourRatingRepository;
        private readonly ITourStatisticsDomainService _tourStatisticsDomainService;
        private readonly IMapper _mapper;
        public TourRatingService(ICrudRepository<TourRating> repository, IMapper mapper, ITourRatingRepository tourRatingRepository, ITourStatisticsDomainService tourStatisticsDomainService) : base(repository, mapper)
        {
            _tourRatingRepository = tourRatingRepository;
            _tourStatisticsDomainService = tourStatisticsDomainService;
            _mapper = mapper;
        }

        public Result<List<TourRatingDto>> GetByTourId(int tourId)
        {
            List<TourRatingDto> tourRatingsDtos = new List<TourRatingDto>();
            var tourRatings = _tourRatingRepository.GetByTourId(tourId);

            foreach (var tourRaing in tourRatings)
            {
                TourRatingDto tourRatingDto = new TourRatingDto
                {
                    Id = (int)tourRaing.Id,
                    UserId = (int)tourRaing.UserId,
                    TourId = (int)tourRaing.TourId,
                    Mark = tourRaing.Mark,
                    Comment = tourRaing.Comment,
                    DateOfVisit = tourRaing.DateOfVisit ?? DateTime.Now,
                    DateOfCommenting = tourRaing.DateOfCommenting,
                    Images = tourRaing.Images
                };
                tourRatingsDtos.Add(tourRatingDto);
            }

            return tourRatingsDtos;
        }

        public Result<List<TourStatisticsDto>> GetBestRatedStatistics()
        {
            var ratings = _tourRatingRepository.GetAll();
            var domainStatistics = _tourStatisticsDomainService.CalculateBestRatedStatisticts(ratings);
            var bestRatedToursStats = new List<TourStatisticsDto>();

            foreach (var stat in domainStatistics)
            {
                TourStatisticsDto statDto = new TourStatisticsDto();
                statDto.TourId = stat.TourId;
                statDto.NumberOfStats = stat.NumberOfStats;
                bestRatedToursStats.Add(statDto);
            }

            return bestRatedToursStats;
        }

        public Result<TourRatingDto> GetByPersonIdAndTourId(long userId, long tourId)
        {
            try
            {
                var rating = _tourRatingRepository.GetByUserIdAndTourId(userId, tourId);
                return MapToDto(rating);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<double> GetAverageAuthorRating(List<TourDto> tours)
        {
            try
            {
                List<TourRatingDto> ratings = new List<TourRatingDto>();

                foreach (var tour in tours)
                {
                    var tourRatingsResult = GetByTourId(tour.Id);
                    if (tourRatingsResult.IsSuccess)
                    {
                        ratings.AddRange(tourRatingsResult.Value);
                    }
                }

                if (ratings.Count == 0)
                {
                    return 0;
                }

                return (double)ratings.Sum(r => r.Mark) / ratings.Count;
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<double> GetAverageTourRating(int tourId)
        {
            try
            {
                var tourRatingsResult = GetByTourId(tourId);

                if (!tourRatingsResult.IsSuccess)
                {
                    return Result.Fail(FailureCode.NotFound).WithError("Ratings for the tour could not be found.");
                }

                var ratings = tourRatingsResult.Value;

                if (ratings.Count == 0)
                {
                    return 0;
                }

                return (double)ratings.Sum(r => r.Mark) / ratings.Count;
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }


    }
}
