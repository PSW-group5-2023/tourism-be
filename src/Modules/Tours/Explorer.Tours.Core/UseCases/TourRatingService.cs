using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Tours.Core.UseCases
{
    public class TourRatingService : /*CrudService<TourRatingDto, TourRating>,*/ ITourRatingService
    {
        //public TourRatingService(ICrudRepository<TourRating> repository, IMapper mapper) : base(repository, mapper) { }

        private readonly ICrudRepository<TourRating> _tourRatingRepository;

        public TourRatingService(ICrudRepository<TourRating> tourRatingRepository)
        {
            _tourRatingRepository = tourRatingRepository;
        }
        public Result<TourRatingDto> Create(TourRatingDto rating)
        {
            try
            {
                var tourRating = _tourRatingRepository.Create(new TourRating(rating.UserId, rating.TourId, rating.Mark, rating.Comment, rating.DateOfVisit, rating.DateOfCommenting, rating.Images));

                return rating;
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
                // There is a subtle issue here. Can you find it?
            }
        }
    }
}
