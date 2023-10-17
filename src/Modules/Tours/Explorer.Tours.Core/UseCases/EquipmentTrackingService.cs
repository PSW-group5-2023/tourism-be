using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;

namespace Explorer.Tours.Core.UseCases;

public class EquipmentTrackingService : CrudService<EquipmentTrackingDto, EquipmentTracking>, IEquipmentTrackingService
{
    public EquipmentTrackingService(ICrudRepository<EquipmentTracking> repository, IMapper mapper) : base(repository, mapper) { }
}