using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Tour
{
    public interface IPublicTourKeyPointService
    {
        Result<PagedResult<PublicTourKeyPointDto>> GetPaged(int page, int pageSize);
        Result<PublicTourKeyPointDto> Get(int id);
        Result<PublicTourKeyPointDto> Create(PublicTourKeyPointDto tourKeyPoint);
        Result<PublicTourKeyPointDto> ChangeStatus(int id, string status);
        Result<List<PublicTourKeyPointDto>> GetByStatus(string status);
        Result Delete(int id);
    }
}
