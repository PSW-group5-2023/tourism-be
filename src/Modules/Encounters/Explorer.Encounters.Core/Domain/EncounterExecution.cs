using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Encounters.Core.Domain
{
    public class EncounterExecution : Entity
    {
        public long TouristId { get; init; }
        public long EncounterId { get; init; }
        public DateTime ActivationTime { get; init; }
        public DateTime? CompletionTime { get; private set; }
        public bool InRange { get; set; }
        public List<SubmittedAnswer> Answers { get; private set; }
        public double? CorrectAnswersPercentage { get; private set; }

        public EncounterExecution()
        {
            
        }

        public EncounterExecution(long touristId, long encounterId, DateTime activationTime, DateTime? completionTime, bool inRange, List<SubmittedAnswer> answers, double? correctAnswersPercentage)
        {
            TouristId = touristId;
            EncounterId = encounterId;
            ActivationTime = activationTime;
            CompletionTime = completionTime;
            InRange = inRange;
            Answers = answers;
            CorrectAnswersPercentage = correctAnswersPercentage;
        }

        public void Complete()
        {
            CompletionTime = DateTime.UtcNow;
        }

        public void SetAnswers(List<SubmittedAnswer> answers)
        {
            Answers = answers;
        }

        public void SetCorrectAnswersPercentage(double correctAnswersPercentage)
        {
            CorrectAnswersPercentage = correctAnswersPercentage;
        }
    }
}
