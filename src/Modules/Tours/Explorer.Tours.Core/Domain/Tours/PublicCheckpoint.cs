using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class PublicCheckpoint : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public Uri Image { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public string Secret { get; init; }
        public PublicCheckpointStatus Status { get; private set; }

        public PublicCheckpoint(string name, string description, Uri image, double latitude, double longitude, string secret, PublicCheckpointStatus status)
        {
            Name = name;
            Description = description;
            Image = image;
            Latitude = latitude;
            Longitude = longitude;
            Secret = secret;
            Status = status;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid name");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid description");
            if (Latitude is > 90 or < -90) throw new ArgumentException("Invalid latitude");
            if (Longitude is > 180 or < -180) throw new ArgumentException("Invalid longitude");
        }

        public void ChangeStatus(PublicCheckpointStatus status)
        {
            Status = status;
        }
    }
    public enum PublicCheckpointStatus
    {
        Approved,
        Denied,
        Pending
    }
}
