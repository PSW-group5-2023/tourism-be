using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Equipment;
using FluentResults;

namespace Explorer.Tours.API.Public.Equipment;

public interface IEquipmentTrackingService
{
    Result<EquipmentTrackingDto> Update(EquipmentTrackingDto dto);
    Result<EquipmentTrackingDto> GetByTouristId(long touristId);
    Result<EquipmentTrackingDto> Create(EquipmentTrackingDto entity);
}