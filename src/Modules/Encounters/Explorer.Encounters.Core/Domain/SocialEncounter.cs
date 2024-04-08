namespace Explorer.Encounters.Core.Domain
{
    public class SocialEncounter : Encounter
    {
        public double RangeInMeters { get; init; }
        public int RequiredAttendance { get; init; }

        public SocialEncounter(long creatorId, string description, string name, EncounterStatus status, EncounterType type, double latitude, double longitude, long? keyPointId, double rangeInMeters, int requiredAttendance) : base(creatorId, description, name, status, type, latitude, longitude, keyPointId)
        {
            RangeInMeters = rangeInMeters;
            RequiredAttendance = requiredAttendance;
        }

        protected override void Validate()
        {
            base.Validate();
            if (RangeInMeters < 1) throw new ArgumentException($"Invalid {nameof(RangeInMeters)}");
            if (RequiredAttendance < 1) throw new ArgumentException($"Invalid {nameof(RequiredAttendance)}");
        }
    }
}
