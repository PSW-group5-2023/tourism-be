using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Internal;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Explorer.Tours.Core.UseCases
{
    public class RecommenderService : BaseService<TourDto, Tour>
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
            var recommendedTours = new List<TourDto>();

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
                    recommendedTours.Add(MapToDto(tour));
                }
            }
        }

        public double calculateJaccardIndex(List<string> firstList, List<string> secondList)
        {
            var intersection = firstList.Intersect(secondList).Count();
            var union = firstList.Union(secondList).Count();

            return intersection / union;
        }

    }
}
