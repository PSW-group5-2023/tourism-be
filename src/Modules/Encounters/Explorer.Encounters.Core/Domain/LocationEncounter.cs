﻿namespace Explorer.Encounters.Core.Domain
{
    public class LocationEncounter : Encounter
    {
        public Uri Image { get; init; }
        public double LocationLatitude { get; init; }
        public double LocationLongitude { get; init; }

        public LocationEncounter(long creatorId, string description, string name, EncounterStatus status, EncounterType type, double latitude, double longitude, long? keyPointId, Uri image, double locationLatitude, double locationLongitude) : base(creatorId, description, name, status, type, latitude, longitude, keyPointId)
        {
            Image = image;
            LocationLatitude = locationLatitude;
            LocationLongitude = locationLongitude;
        }

        protected override void Validate()
        {
            base.Validate();
            if (LocationLatitude is > 90 or < -90) throw new ArgumentException($"Invalid {nameof(LocationLatitude)}");
            if (LocationLongitude is > 180 or < -180) throw new ArgumentException($"Invalid {nameof(LocationLongitude)}");
        }
    }
}
