using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.Sessions.DomainEvents
{
    public class KeyPointCompleted : DomainEvent
    {
        public DateTime TimeOfCompletion { get; set; }
        public KeyPointCompleted(long id, DateTime timeOfCompletion) : base(id)
        {
            TimeOfCompletion = timeOfCompletion;
        }
    }
}
