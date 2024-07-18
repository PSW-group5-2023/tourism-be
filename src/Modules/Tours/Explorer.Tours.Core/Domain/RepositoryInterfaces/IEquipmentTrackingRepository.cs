using Explorer.Tours.Core.Domain.Equipment;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IEquipmentTrackingRepository
    {
        EquipmentTracking GetByTouristId(long id);
        EquipmentTracking Update(EquipmentTracking entity);
        EquipmentTracking Create(EquipmentTracking entity);
    }
}
