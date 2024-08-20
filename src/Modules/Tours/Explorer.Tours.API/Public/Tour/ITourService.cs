using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Dtos.Tour.Tourist;
using FluentResults;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Explorer.Tours.API.Public.Tour
{
    public interface ITourService
    {
        Result<PagedResult<TourDto>> GetPaged(int page, int pageSize);
        Result<PagedResult<TourMobileDto>> GetPagedMobile(int page, int pageSize);
        Result<PagedResult<TourMobileDto>> GetPagedSortedByLatestMobile(int page, int pageSize);
        Result<PagedResult<TourMobileDto>> GetPagedSortedByPopularMobile(int page, int pageSize);
        Result<TourDto> Create(TourDto tour);
        Result<TourDto> Update(TourDto tour);
        Result Delete(int id);
        Result<TourDto> Get(int id);
        Result<TourMobileDto> GetMobile(int id);
        Result<TourDto> GetById(long id);
        Result<TourDto> Publish(int id, int userId);
        Result<TourDto> Archive(int id, int userId);
        Result<PagedResult<TourDto>> GetPagedByAuthorId(int authorId, int page, int pageSize);
        Result<PagedResult<TourDto>> GetPagedForSearch(string name, string[] tags, int page, int pageSize);
        Result<TourDto> CreateCampaign(List<TourDto> tours, string name, string description, int touristId);
        Result<PagedResult<TourMobileDto>> GetPagedMobileByLocation(int page, int pageSize, LocationMobileDto location);
        List<TourDto> GetAllByAuthorId(int authorId);
        Result<PagedResult<TourMobileDto>> GetPagedMobileByRating(int page, int pageSize, int rating);
    }
}
