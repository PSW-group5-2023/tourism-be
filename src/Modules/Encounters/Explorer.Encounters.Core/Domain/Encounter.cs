using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Encounters.Core.Domain
{
    public class Encounter : Entity
    {
        public long CreatorId { get; init; }
        public string Description { get; init; }
        public string Name { get; init; }
        public EncounterStatus Status { get; init; }
        public EncounterType Type { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public int ExperiencePoints { get; init; }
        public long? KeyPointId { get; init; }

        public Encounter(long creatorId, string description, string name, EncounterStatus status, EncounterType type, double latitude, double longitude, long? keyPointId)
        {
            CreatorId = creatorId;
            Description = description;
            Name = name;
            Status = status;
            Type = type;
            Latitude = latitude;
            Longitude = longitude;
            KeyPointId = keyPointId;
            Validate();
        }

        protected virtual void Validate()
        {
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException($"Invalid {nameof(Description)}");
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException($"Invalid {nameof(Name)}");
            if (Latitude is > 90 or < -90) throw new ArgumentException($"Invalid {nameof(Latitude)}");
            if (Longitude is > 180 or < -180) throw new ArgumentException($"Invalid {nameof(Longitude)}");
            if (ExperiencePoints < 1) throw new ArgumentException($"Invalid {nameof(ExperiencePoints)}");
        }
    }

    public enum EncounterStatus
    {
        Draft,
        Active,
        Archived
    }

    public enum EncounterType
    {
        Social,
        Location,
        Misc
    }
}
