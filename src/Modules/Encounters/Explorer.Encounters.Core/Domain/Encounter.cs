using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Encounters.Core.Domain
{
    public class Encounter : Entity
    {
        public long CreatorId { get; init; }
        public string Description { get; init; }
        public string Name { get; init; }
        public EncounterStatus Status { get; private set; }
        public EncounterType Type { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public int ExperiencePoints { get; init; }
        public long? KeyPointId { get; init; }
        public bool IsMandatory { get; init; }

        public Encounter(long creatorId, string description, string name, EncounterStatus status, EncounterType type, double latitude, double longitude, long? keyPointId, int experiencePoints, bool isMandatory)
        {
            CreatorId = creatorId;
            Description = description;
            Name = name;
            Status = status;
            Type = type;
            Latitude = latitude;
            Longitude = longitude;
            KeyPointId = keyPointId;
            ExperiencePoints = experiencePoints;
            Validate();
            IsMandatory = isMandatory;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException($"Invalid {nameof(Description)}");
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException($"Invalid {nameof(Name)}");
            if (Latitude is > 90 or < -90) throw new ArgumentException($"Invalid {nameof(Latitude)}");
            if (Longitude is > 180 or < -180) throw new ArgumentException($"Invalid {nameof(Longitude)}");
            if (ExperiencePoints < 1) throw new ArgumentException($"Invalid {nameof(ExperiencePoints)}");
        }

        public void Activate()
        {
            Status = EncounterStatus.Active;
        }

        public void Archive()
        {
            Status = EncounterStatus.Archived;
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
