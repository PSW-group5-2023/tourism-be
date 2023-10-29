using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Tours.API.Public;

public interface IEquipmentTrackingService
{
    Result<EquipmentTrackingDto> Update(EquipmentTrackingDto equipment);
    Result<EquipmentTrackingDto> GetByTouristId(long touristId);
}