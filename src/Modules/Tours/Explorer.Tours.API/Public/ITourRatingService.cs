using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public
{
    public interface ITourRatingService
    {
        Result<PagedResult<TourRatingDto>> GetPaged(int page, int pageSize);
        Result<TourRatingDto> Get(int id);
        Result<TourRatingDto> Create(TourRatingDto rating);
    }
}
