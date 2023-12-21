using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases
{
    public class RecommenderService 
    {
        private readonly ITourRepository _tourRepository;
        private readonly IPreferencesRepository _preferencesRepository;
        private readonly ITourRatingRepository _ratingRepository;
        public RecommenderService(ITourRepository tourRepository, IPreferencesRepository preferencesRepository, ITourRatingRepository ratingRepository)
        {
            _tourRepository = tourRepository;
            _preferencesRepository = preferencesRepository;
            _ratingRepository = ratingRepository;
        }

        public Result<PagedResult<TourDto>> GetActiveToursByUserId(int userId, int page, int pageSize)
        {
            var allTours = _tourRepository.GetPaged(page, pageSize);




            // var result = _tourRepository.GetPagedByAuthorId(authorId, page, pageSize);
           // return MapToDto(result);
        }
    }
}
