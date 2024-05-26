namespace Explorer.Encounters.Core.Domain
{
    public class LocationEncounter : Encounter
    {
        public Uri Image { get; init; }
        public double LocationLatitude { get; init; }
        public double LocationLongitude { get; init; }

        public LocationEncounter(long creatorId, string description, string name, EncounterStatus status, EncounterType type, double latitude, double longitude, long? checkpointId, int experiencePoints, bool isMandatory, Uri image, double locationLatitude, double locationLongitude) : base(creatorId, description, name, status, type, latitude, longitude, checkpointId, experiencePoints, isMandatory)
        {
            Image = image;
            LocationLatitude = locationLatitude;
            LocationLongitude = locationLongitude;
            if (LocationLatitude is > 90 or < -90) throw new ArgumentException($"Invalid {nameof(LocationLatitude)}");
            if (LocationLongitude is > 180 or < -180) throw new ArgumentException($"Invalid {nameof(LocationLongitude)}");
        }
    }
}
