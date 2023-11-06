using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Tours.Core.UseCases
{
    public class TourRatingService : CrudService<TourRatingDto, TourRating>, ITourRatingService
    {
        private readonly ITourRatingRepository _tourRatingRepository;
        public TourRatingService(ICrudRepository<TourRating> repository, IMapper mapper, ITourRatingRepository tourRatingRepository) : base(repository, mapper)
        { 
            _tourRatingRepository = tourRatingRepository;
        }

        public Result<List<TourRatingDto>> GetByTourId(int tourId)
        {
            List<TourRatingDto> tourRatingsDtos = new List<TourRatingDto>();
            var tourRatings = _tourRatingRepository.GetByTourId(tourId);

            foreach (var tourRaing in tourRatings)
            {
                TourRatingDto tourRatingDto = new TourRatingDto
                {
                    PersonId = (int)tourRaing.PersonId,
                    TourId = (int)tourRaing.TourId,
                    Mark = (int)tourRaing.Mark,
                    Comment = tourRaing.Comment,
                    DateOfVisit = tourRaing.DateOfVisit,
                    DateOfCommenting = tourRaing.DateOfCommenting,
                    Images = tourRaing.Images
                };
                tourRatingsDtos.Add(tourRatingDto);
            }

            return tourRatingsDtos;
        }
    }
}
