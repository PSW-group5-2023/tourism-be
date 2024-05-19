using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class TourDuration : ValueObject
    {
        public uint TimeInSeconds { get; init; }
        public TransportationType Transportation { get; init; }

        [JsonConstructor]
        public TourDuration(uint timeInSeconds, TransportationType transportation)
        {
            TimeInSeconds = timeInSeconds;
            Transportation = transportation;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TimeInSeconds;
            yield return Transportation;
        }
    }
    public enum TransportationType
    {
        Walking,
        Bicycle,
        Car
    }
}
