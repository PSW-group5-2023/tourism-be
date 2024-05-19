using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;

namespace Explorer.Tours.Core.Domain.Sessions
{
    public class CompletedKeyPoint : ValueObject
    {   
        public int KeyPointId { get; init; }
        public DateTime CompletionTime { get; init; }

        [JsonConstructor]
        public CompletedKeyPoint(int keyPointId, DateTime completionTime)
        {
            KeyPointId = keyPointId;
            CompletionTime = completionTime;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return KeyPointId;
            yield return CompletionTime;
        }
    }
}
