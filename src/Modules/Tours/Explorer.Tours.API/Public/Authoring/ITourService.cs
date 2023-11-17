using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Tours.API.Public.Authoring
{
    public interface ITourService
    {
        Result<PagedResult<TourDto>> GetPaged(int page, int pageSize);
        Result<TourDto> Create(TourDto tour);
        Result<TourDto> Update(TourDto tour);
        Result Delete(int id);
        Result<TourDto> Get(int id);
        Result<TourDto> Publish(int id, int userId);
        Result<TourDto> Archive(int id, int userId);
        Result<PagedResult<TourDto>> GetPagedByAuthorId(int authorId, int page, int pageSize);
    }
}
