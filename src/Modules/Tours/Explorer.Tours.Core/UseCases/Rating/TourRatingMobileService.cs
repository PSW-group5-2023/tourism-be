using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Rating;
using Explorer.Tours.API.Public.Rating;
using Explorer.Tours.Core.Domain.Rating;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Rating
{
    public class TourRatingMobileService : CrudService<TourRatingMobileDto, TourRating>, ITourRatingMobileService
    {
        public TourRatingMobileService(ICrudRepository<TourRating> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }
        public Result<TourRatingMobileDto> Create(TourRatingMobileDto rating)
        {
            try
            {
                if (rating.Mark > 5 || rating.Mark < 1) throw new ArgumentException("Invalid Mark");
                if (string.IsNullOrWhiteSpace(rating.Comment)) throw new ArgumentException("Invalid Comment");
                var result = CrudRepository.Create(MapToDomain(rating));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }
    }
}
