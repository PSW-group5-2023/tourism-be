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


        public Result<PagedResult<TourDto>> GetRecommendedTours(int page, int pageSize, int userId)
        {
            var preference = _preferencesRepository.GetByUserId(userId);
            var tours = _tourRepository.GetPaged(page, pageSize);
            var publishedTours = tours.Results.Select(tour => tour.Status == Domain.Tours.TourStatus.Published).ToList();

            var usedBoughtItems = _internalBoughtItemService.GetUsedByUserId(userId);
            var usedTours = new List<TourDto>();
            var recommendedTours = new PagedResult<TourDto>(new List<TourDto>(), 0);

            foreach (var item in usedBoughtItems.Value)
            {
                usedTours.Add(MapToDto(_tourRepository.Get(item.TourId)));
            }


            foreach (var tour in tours.Results)
            {
                // similarity based on preferences tags
                var tagsSimilarity = calculateJaccardIndex(tour.Tags, preference.Tags);


                // similarity based on used tours
                var usedToursIndexes = 0.0;
                foreach (var item in usedTours)
                {
                    usedToursIndexes += calculateJaccardIndex(tour.Tags, item.Tags);
                }

                var usedToursSimilarity = usedToursIndexes / usedTours.Count;


                // similarity based on difficulty preference
                var difficultyRelativeError = Math.Abs((double)(tour.Difficulty - preference.DifficultyLevel)) / preference.DifficultyLevel;

                if(tagsSimilarity >= 0.6 && difficultyRelativeError <= 0.4 && usedToursSimilarity >= 0.6)
                {
                    recommendedTours.Results.Add(MapToDto(tour));
                }
            }

            return null;
        }

        public double calculateJaccardIndex(List<string> firstList, List<string> secondList)
        {
            var intersection = firstList.Intersect(secondList).Count();
            var union = firstList.Union(secondList).Count();

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
