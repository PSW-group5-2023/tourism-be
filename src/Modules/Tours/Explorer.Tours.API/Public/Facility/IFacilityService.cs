﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Facility;
using FluentResults;

namespace Explorer.Tours.API.Public.Facility
{
    public interface IFacilityService
    {
        Result<PagedResult<FacilityDto>> GetPaged(int page, int pageSize);
        Result<FacilityDto> Get(int id);
        Result<FacilityDto> Create(FacilityDto objectDto);
        Result<FacilityDto> Update(FacilityDto objectDto);
        Result Delete(int id);
    }
}
