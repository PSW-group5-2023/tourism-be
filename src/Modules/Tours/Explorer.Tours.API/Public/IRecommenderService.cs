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
    public interface IRecommenderService
    {
        Result<PagedResult<TourDto>> GetActive(int userId, int page, int pageSize);
        Result<PagedResult<TourDto>> GetRecommendedTours(int page, int pageSize, int userId);
    }
}

