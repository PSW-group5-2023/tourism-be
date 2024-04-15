using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class Checkpoint : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public Uri Image { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public long TourId { get; init; }
        public string? Secret { get; init; }
        public int PositionInTour { get; init; }

        public Checkpoint(string name, string description, Uri image, double latitude, double longitude, int positionInTour, long tourId, string secret)
        {
            Name = name;
            Description = description;
            Image = image;
            Latitude = latitude;
            Longitude = longitude;
            TourId = tourId;
            Secret = secret;
            PositionInTour = positionInTour;
            Validate();
            
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid name");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid description");
            if (Latitude is > 90 or < -90) throw new ArgumentException("Invalid latitude");
            if (Longitude is > 180 or < -180) throw new ArgumentException("Invalid longitude");
        }

    }
}
