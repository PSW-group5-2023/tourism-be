using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Facility;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Facility
{
    public interface IPublicFacilityService
    {
        Result<PagedResult<PublicFacilityDto>> GetPaged(int page, int pageSize);
        Result<PublicFacilityDto> Get(int id);
        Result<PublicFacilityDto> Create(PublicFacilityDto tourKeyPoint);
        Result<PublicFacilityDto> ChangeStatus(int id, string status);

        Result<List<PublicFacilityDto>> GetByStatus(string status);
        Result Delete(int id);
    }
}
