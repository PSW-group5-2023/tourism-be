using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.Sessions.DomainEvents
{
    public class LocationUpdated : DomainEvent
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public LocationUpdated(long id, double latitude, double longitude) : base(id)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
