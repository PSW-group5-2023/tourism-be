using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain
{
    public class EquipmentTracking : Entity
    {
        public long TouristId { get; init; }
        public List<long> NeededEquipment { get; init; }
        public EquipmentTracking(List<long> neededEquipment) 
        {
            foreach (var item in neededEquipment)
            {
                if (string.IsNullOrWhiteSpace(item.ToString())) throw new ArgumentException("Invalid NeededEquipment.");
            }
            NeededEquipment = neededEquipment;
        }
    }
}
