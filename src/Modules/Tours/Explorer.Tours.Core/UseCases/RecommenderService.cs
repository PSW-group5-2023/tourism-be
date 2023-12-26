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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Explorer.Tours.Core.UseCases
{

    public class RecommenderService : BaseService<TourDto, Tour>, IRecommenderService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IPreferencesRepository _preferencesRepository;
        private readonly ITourRatingRepository _tourRatingRepository;
        private readonly IInternalBoughtItemService _internalBoughtItemService;

        public RecommenderService(IMapper mapper, ITourRepository tourRepository, IPreferencesRepository preferencesRepository, ITourRatingRepository tourRatingRepository, IInternalBoughtItemService internalBoughtItemService) : base(mapper) 
        {
            _tourRepository = tourRepository;
            _preferencesRepository = preferencesRepository;
            _tourRatingRepository = tourRatingRepository;
            _internalBoughtItemService = internalBoughtItemService;
        }


        public Result<PagedResult<TourDto>> GetRecommendedTours(int userId, int page, int pageSize)
        {
            var preference = _preferencesRepository.GetByUserId(userId);
            var tours = _tourRepository.GetPaged(page, pageSize);
            var publishedTours = tours.Results.Where(tour => tour.Status == Domain.Tours.TourStatus.Published).ToList();
            var usedBoughtItems = _internalBoughtItemService.GetUsedByUserId(userId);
            var usedTours = new List<TourDto>();
            var recommendedTours = new PagedResult<TourDto>(new List<TourDto>(), 0);
            var tourIndexes = new Dictionary<long, double>();

            foreach (var item in usedBoughtItems.Value)
            {
                usedTours.Add(MapToDto(_tourRepository.Get(item.TourId)));
                if(usedTours.Count == 10)
                {
                    break;
                }
            }


            foreach (var tour in publishedTours)
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
                recommendedTours.Results.Add(MapToDto(tours.Results.Find(t => t.Id == tour.Key)));
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

        public double getUsedToursSimilarityIndex(List<TourDto> usedTours, Tour tour)
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

        public Result<PagedResult<TourDto>> GetActive(int userId, int page, int pageSize)
        {
            var allTours = _tourRepository.GetPaged(page, pageSize);
            DateTime lastWeek = DateTime.Today.AddDays(-7);
            foreach (var tour in allTours.Results)
            {
                var ratingsInLastWeek = _tourRatingRepository.GetByTourId((int)tour.Id).Where(x => x.DateOfCommenting >= lastWeek).ToList();
                int countOfRatings = ratingsInLastWeek.Count;
                double averageSum = ratingsInLastWeek.Sum(r => r.Mark) / (double)countOfRatings;
                Result<List<BoughtItemDto>> result = _internalBoughtItemService.GetByTourId(tour.Id);
                int count = result.Value.Count;

            }
            //return MapToDto(allTours);
            return null;
        }
    }
}
