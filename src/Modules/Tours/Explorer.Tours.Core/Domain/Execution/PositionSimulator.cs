﻿using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.Sessions
{
    public class PositionSimulator : Entity
    {
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public long TouristId { get; init; }
        public PositionSimulator(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;

            Validate();
        }

        private void Validate()
        {
            if (Latitude is > 90 or < -90) throw new ArgumentException("Invalid latitude");
            if (Longitude is > 180 or < -180) throw new ArgumentException("Invalid longitude");
        }
    }
}