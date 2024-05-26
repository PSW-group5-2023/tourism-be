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
    public interface IPublicCheckpointService
    {
        Result<PagedResult<PublicCheckpointDto>> GetPaged(int page, int pageSize);
        Result<PublicCheckpointDto> Get(int id);
        Result<PublicCheckpointDto> Create(PublicCheckpointDto tourKeyPoint);
        Result<PublicCheckpointDto> ChangeStatus(int id, string status);
        Result<List<PublicCheckpointDto>> GetByStatus(string status);
        Result Delete(int id);
    }
}
