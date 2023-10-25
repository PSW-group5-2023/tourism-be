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
    public class TourRatingService : CrudService<TourRatingDto, TourRating>, ITourRatingService
    {
        public TourRatingService(ICrudRepository<TourRating> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
