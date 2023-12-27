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
        Result<PagedResult<TourDto>> GetRecommendedToursByLocation(int userId, int page, int pageSize);
        Result<PagedResult<TourDto>> GetActiveToursByLocation(int userId, int page, int pageSize);
        Result<PagedResult<TourDto>> GetRecommendedToursFromFollowings(int tourId, int userId);
        Result<bool> SendEmail(string to, string subject, string body);
    }
}

