﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Facility;
using Explorer.Tours.API.Public.Facility;
using Explorer.Tours.Core.Domain.Facilities;

namespace Explorer.Tours.Core.UseCases.Facilities
{
    public class FacilityService : CrudService<FacilityDto, Facility>, IFacilityService
    {
        public FacilityService(ICrudRepository<Facility> crudRepository, IMapper mapper) : base(crudRepository, mapper) { }
    }
}
