
namespace Explorer.Encounters.API.Dtos
{
    public class ChallengeExecutionDto
    {
        public long TouristId { get; init; }
        public long ChallengeId { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public DateTime ActivationTime { get; init; }
        public DateTime? CompletionTime { get; init; }
    }
}
