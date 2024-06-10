namespace Explorer.Encounters.Core.Domain
{
    public class QuizEncounter : Encounter
    {
        public ICollection<Question> Questions { get; init; } = new List<Question>();

        public QuizEncounter() { }

        public QuizEncounter(long creatorId, string description, string name, EncounterStatus status, EncounterType type, double latitude, double longitude, long? checkpointId, int experiencePoints, bool isMandatory, long? achievementId, ICollection<Question> questions) : base(creatorId, description, name, status, type, latitude, longitude, checkpointId, experiencePoints, isMandatory, achievementId)
        {
            Questions = questions ?? new List<Question>();
        }
    }
}
