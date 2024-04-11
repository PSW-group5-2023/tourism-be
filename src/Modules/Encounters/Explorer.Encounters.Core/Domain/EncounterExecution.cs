using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Encounters.Core.Domain
{
    public class EncounterExecution : Entity
    {
        public long TouristId { get; init; }
        public long EncounterId { get; init; }
        public DateTime ActivationTime { get; init; }
        public DateTime? CompletionTime { get; private set; }


        public EncounterExecution(long touristId, long encounterId, DateTime activationTime, DateTime? completionTime)
        {
            TouristId = touristId;
            EncounterId = encounterId;
            ActivationTime = activationTime;
            CompletionTime = completionTime;
        }

        public void Complete()
        {
            CompletionTime = DateTime.UtcNow;
        }
    }
}
