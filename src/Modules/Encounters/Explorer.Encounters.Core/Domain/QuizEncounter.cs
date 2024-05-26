namespace Explorer.Encounters.Core.Domain
{
    public class QuizEncounter : Encounter
    {
        public ICollection<Question> Questions { get; init; }

        public QuizEncounter()
        {

        }
    }
}
