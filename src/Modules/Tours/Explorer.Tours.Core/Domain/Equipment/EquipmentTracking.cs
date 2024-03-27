using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.Equipment
{
    public class EquipmentTracking : Entity
    {
        public long TouristId { get; init; }
        public List<long> NeededEquipment { get; init; }
        public EquipmentTracking()
        {
            NeededEquipment = new List<long>();
        }
    }
}
