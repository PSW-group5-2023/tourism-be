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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Explorer.Tours.Core.UseCases
{

    public class RecommenderService : BaseService<TourDto, Tour>, IRecommenderService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IPreferencesRepository _preferencesRepository;
        private readonly ITourRatingRepository _tourRatingRepository;
        private readonly IInternalBoughtItemService _internalBoughtItemService;
        private readonly ITourService _tourService;

        public RecommenderService(IMapper mapper, ITourRepository tourRepository, IPreferencesRepository preferencesRepository, ITourRatingRepository tourRatingRepository, IInternalBoughtItemService internalBoughtItemService, ITourService tourService) : base(mapper) 
        {
            _tourRepository = tourRepository;
            _preferencesRepository = preferencesRepository;
            _tourRatingRepository = tourRatingRepository;
            _internalBoughtItemService = internalBoughtItemService;
            _tourService = tourService;
        }

        public Result<PagedResult<TourDto>> GetRecommendedToursByLocation(int page, int pageSize, int touristId)
        {
            var publishedTours = _tourService.GetPagedForSearchByLocation(page, pageSize, touristId);

            return GetRecommendedTours(touristId, MapToDomain(publishedTours.Value.Results));
        }

        public Result<PagedResult<TourDto>> GetRecommendedTours(int userId, List<Tour> tours)
        {
            var preference = _preferencesRepository.GetByUserId(userId);   
            var usedBoughtItems = _internalBoughtItemService.GetUsedByUserId(userId);

            var usedTours = new List<Tour>();
            var recommendedTours = new PagedResult<TourDto>(new List<TourDto>(), 0);
            var tourIndexes = new Dictionary<long, double>();

            var toursToRecommend = new List<Tour>();
            foreach (var item in usedBoughtItems.Value)
            {
                if(usedTours.Count <= 10)
                {
                    usedTours.Add(_tourRepository.Get(item.TourId));
                }

                if(tours.Any(t => t.Id == item.TourId))
                {
                    tours.Remove(_tourRepository.Get(item.TourId));
                }
            }


            foreach (var tour in tours)
            {
                double tagsSimilarity = getPreferencesTagsSimilarityIndex(preference, tour);

                double difficultyError = getPreferencesDifficultySimilarityIndex(preference, tour);

                double usedToursSimilarity = getUsedToursSimilarityIndex(usedTours, tour);

                double ratingIndex = getRatingIndex(tour);


                // make one similarity index and bind it to tour
                double averageSimilarityIndexes = (tagsSimilarity + usedToursSimilarity + difficultyError + ratingIndex) / 4;
                tourIndexes[tour.Id] = averageSimilarityIndexes;
            }

            var sortedToursByIndexes = tourIndexes.OrderByDescending(x => x.Value);

            foreach(KeyValuePair<long, double> tour in sortedToursByIndexes)
            {
                recommendedTours.Results.Add(MapToDto(tours.Find(t => t.Id == tour.Key)));
            }

            return recommendedTours;
        }

        public double getPreferencesTagsSimilarityIndex(Preferences preference, Tour tour)
        {
            double tagsSimilarity = 0.0;
            if (preference != null)
            {
                // similarity based on preferences tags
                tagsSimilarity = calculateJaccardIndex(tour.Tags, preference.Tags);
            }

            return tagsSimilarity;
        }

        public double getPreferencesDifficultySimilarityIndex(Preferences preference, Tour tour)
        {
            double difficultyError = 1.0;
            if (preference != null)
            {
                // similarity based on difficulty preference
                difficultyError = Math.Abs((double)(tour.Difficulty - preference.DifficultyLevel)) / 3;
            }

            // because 0 should represent the worst index and 1 should represent the best ( difficultyLevel is vice versa )
            double inverseDifficultyError = 1 - difficultyError;
            

            return inverseDifficultyError;
        }

        public double getUsedToursSimilarityIndex(List<Tour> usedTours, Tour tour)
        {
            // similarity based on used tours
            double usedToursSimilarity = 0.0;
            if (usedTours.Count != 0)
            {
                double usedToursIndexes = 0.0;
                foreach (var item in usedTours)
                {
                    usedToursIndexes += calculateJaccardIndex(tour.Tags, item.Tags);
                }

                usedToursSimilarity = usedToursIndexes / usedTours.Count;
            }

            return usedToursSimilarity;
        }

        public double getRatingIndex(Tour tour)
        {
            var tourRatings = _tourRatingRepository.GetByTourId((int)tour.Id);

            double ratingIndex = 0.0;
            if(tourRatings.Count >= 5)
            {
                double sumRating = 0.0;
                foreach (var rating in tourRatings)
                {
                    sumRating += rating.Mark;
                }
                double averageRating = sumRating / tourRatings.Count;
                
                if(averageRating > 4.0)
                {
                    ratingIndex = averageRating - 4.0;
                }
            }

            return ratingIndex;
        }


        public double calculateJaccardIndex(List<string> firstList, List<string> secondList)
        {
            double intersection = firstList.Intersect(secondList).Count();
            double union = firstList.Union(secondList).Count();

            return intersection / union;
        }

        public Result<PagedResult<TourDto>> GetActiveToursByLocation(int userId, int page, int pageSize)
        {
            var tours = _tourRepository.GetPaged(page, pageSize);
            var publishedTours = tours.Results.Where(tour => tour.Status == Domain.Tours.TourStatus.Published).ToList();

            return GetActiveTours(publishedTours);
        }

        public Tuple<double, double> getRatingParameters(Tour tour, int totalRatings)
        {
            DateTime lastWeek = DateTime.Today.AddDays(-7);
            var ratingsInLastWeek = _tourRatingRepository.GetByTourId((int)tour.Id).Where(x => x.DateOfCommenting >= lastWeek).ToList();
            double ratingsCount = ratingsInLastWeek?.Count() ?? 0;
            double ratingsSum = 0;
            foreach( var r in ratingsInLastWeek)
            {
                ratingsSum += r.Mark;
            }
            double averageRating = (ratingsCount > 0) ? (ratingsSum / ratingsCount) : 0;
            double ratingPercentage = (totalRatings > 10) ? (ratingsCount / totalRatings) : 0;
            return new Tuple<double, double>(averageRating, ratingPercentage);
        }

        public double getBoughtParameters(Tour tour, int totalBoughts)
        {
            DateTime lastWeek = DateTime.Today.AddDays(-7);
            var boughts = _internalBoughtItemService.GetByTourId(tour.Id).Value;
            double boughtsCount = boughts?.Count() ?? 0;
            double boughtPercentage = (totalBoughts > 10) ? (boughtsCount / totalBoughts) : 0;
            return boughtPercentage;
        }

        public double calculateScoreForActiveTour(Tour tour, int totalBoughts, int totalRatings)
        {
            double normalizedAvgRating = (getRatingParameters(tour, totalRatings).Item1)/5;
            double ratingPercentage = getRatingParameters(tour, totalRatings).Item2;
            double boughtPercentage = getBoughtParameters(tour, totalBoughts);
            return 0.2 * normalizedAvgRating + 0.4 * ratingPercentage + 0.4 * boughtPercentage;
        }
        public Result<PagedResult<TourDto>> GetActiveTours(List<Tour> tours)
        {
            var activeTours = new PagedResult<TourDto>(new List<TourDto>(), 0);
            var tourIdToTourScoreMap = new Dictionary<long, double>();
            int totalBoughts = _internalBoughtItemService.GetAll().Value?.Count() ?? 0;
            DateTime lastWeek = DateTime.Today.AddDays(-7);
            int totalRankings = _tourRatingRepository.GetAll().Where(x => x.DateOfCommenting >= lastWeek)?.Count() ?? 0;
            foreach (var t in tours)
            {
                tourIdToTourScoreMap[t.Id] = calculateScoreForActiveTour(t, totalBoughts, totalRankings);
            }
            var sortedToursByScore = tourIdToTourScoreMap.OrderByDescending(x => x.Value).ToList();
            foreach (KeyValuePair<long, double> tour in sortedToursByScore)
            {
                activeTours.Results.Add(MapToDto(tours.Find(t => t.Id == tour.Key)));
            }

            return activeTours;
        }
    }
}
