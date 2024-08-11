using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Equipment;
using Explorer.Tours.API.Public.Equipment;
using Explorer.Tours.Core.Domain.Equipment;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Equipments;

public class EquipmentTrackingService : BaseService<EquipmentTrackingDto, EquipmentTracking>, IEquipmentTrackingService
{
    private readonly IEquipmentTrackingRepository _equipmentTrackingRepository;
    public EquipmentTrackingService(ICrudRepository<EquipmentTracking> repository, IMapper mapper, IEquipmentTrackingRepository equipmentTrackingRepository) : base(mapper)
    {
        _equipmentTrackingRepository = equipmentTrackingRepository;
    }
    public Result<EquipmentTrackingDto> GetByTouristId(long touristId)
    {
        EquipmentTracking entity = _equipmentTrackingRepository.GetByTouristId(touristId);
        if (entity == null) return Result.Fail(FailureCode.InvalidArgument).WithError("Entity not found.");
        return MapToDto(entity);
    }

    public Result<EquipmentTrackingDto> Update(EquipmentTrackingDto dto)
    {
        try
        {
            var result = _equipmentTrackingRepository.Update(MapToDomain(dto));
            return MapToDto(result);
        }
        catch (KeyNotFoundException e)
        {
            return Result.Fail(FailureCode.NotFound).WithError(e.Message);
        }
        catch (ArgumentException e)
        {
            return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
        }
    }
    public virtual Result<EquipmentTrackingDto> Create(EquipmentTrackingDto entity)
    {
        try
        {
            var result = _equipmentTrackingRepository.Create(MapToDomain(entity));
            return MapToDto(result);
        }
        catch (ArgumentException e)
        {
            return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
        }
    }
}