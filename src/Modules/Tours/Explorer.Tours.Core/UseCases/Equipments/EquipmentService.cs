using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Equipment;
using Explorer.Tours.API.Public.Equipment;
using Explorer.Tours.Core.Domain.Equipment;

namespace Explorer.Tours.Core.UseCases.Equipments;

public class EquipmentService : CrudService<EquipmentDto, Equipment>, IEquipmentService
{
    public EquipmentService(ICrudRepository<Equipment> repository, IMapper mapper) : base(repository, mapper) { }
}