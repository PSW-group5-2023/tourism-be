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
