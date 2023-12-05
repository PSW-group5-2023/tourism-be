using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Encounters.Core.Domain
{
    public class ChallengeExecution : Entity
    {
        public long TouristId { get; init; }
        public long ChallengeId { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public DateTime ActivationTime { get; init; }
        public DateTime? CompletionTime { get; init; }

        public ChallengeExecution(long touristId, long challengeId, double latitude, double longitude,
            DateTime activationTime, DateTime? completionTime)
        {
            TouristId = touristId;
            ChallengeId = challengeId;
            Latitude = latitude;
            Longitude = longitude;
            ActivationTime = activationTime;
            CompletionTime = completionTime;
        }
    }
}
