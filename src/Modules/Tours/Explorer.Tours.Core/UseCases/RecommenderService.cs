using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Internal;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Authoring;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.UseCases.Authoring;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Explorer.Tours.Core.UseCases
{
    public class RecommenderService : IRecommenderService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IPreferencesRepository _preferencesRepository;
        private readonly ITourRatingRepository _tourRatingRepository;
        private readonly IInternalBoughtItemService _internalBoughtItemService;

        public RecommenderService(ITourRepository tourRepository, IPreferencesRepository preferencesRepository, ITourRatingRepository tourRatingRepository, IInternalBoughtItemService internalBoughtItemService)
        {
            _tourRepository = tourRepository;
            _preferencesRepository = preferencesRepository;
            _tourRatingRepository = tourRatingRepository;
            _internalBoughtItemService = internalBoughtItemService;
        }

        public double CalculateScore(int totalRatings, int totalBoughts,int countOfRatings, int countOfBoughts, double averageRating)
        {
            double ratingsPercentage = (countOfRatings / (double)totalRatings);
            double boughtsPercentage = (countOfBoughts / (double)totalBoughts);
            double normalizedRating = (averageRating / 5);

            return 0.3*ratingsPercentage + 0.5*boughtsPercentage + 0.3*normalizedRating;
        }



        //public Result<PagedResult<TourDto>> GetActive(int userId, int page, int pageSize)
        public Result<PagedResult<TourDto>> GetActive(int userId, int page, int pageSize)
        {
            DateTime lastWeek = DateTime.Today.AddDays(-7);
            var allTours = _tourRepository.GetPaged(page, pageSize).Results.Where(x=> x.Status == TourStatus.Published);
            int totalRatingsInLastWeek = _tourRatingRepository.GetAll().Where(x => x.DateOfCommenting >= lastWeek)?.Count() ?? 0;
            int totalBoughts = _internalBoughtItemService.GetAll().Value?.Count() ?? 0;
            var tourScores = new Dictionary<long, double>();

            foreach (var tour in allTours)
            {
                var tourRatingsInLastWeek = _tourRatingRepository.GetByTourId((int)tour.Id).Where(x => x.DateOfCommenting >= lastWeek).ToList();
                double averageRating = 0;
                int countOfRatings = tourRatingsInLastWeek?.Count() ?? 0;
                if (totalRatingsInLastWeek > 15)
                {
                    countOfRatings = 0;
                //Bayesian average za average i broj ratinga
                }
                if (countOfRatings > 15)
                {
                    averageRating = tourRatingsInLastWeek.Sum(r => r.Mark) / (double)countOfRatings;
                }
                int countOfBoughts = _internalBoughtItemService.GetByTourId(tour.Id).Value?.Count() ?? 0;
                tourScores[tour.Id] = CalculateScore(totalRatingsInLastWeek, totalBoughts, countOfRatings, countOfBoughts, averageRating);
            }
            //return MapToDto(sortedTours);
            return null;
        }
    }
}
