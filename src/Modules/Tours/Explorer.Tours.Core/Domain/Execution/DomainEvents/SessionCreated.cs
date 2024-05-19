using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.Sessions.DomainEvents
{
    public class SessionCreated : DomainEvent
    {
        public DateTime TimeOfCreation { get; set; }

        public SessionCreated(long id, DateTime timeOfCreation) : base(id)
        {
            TimeOfCreation = timeOfCreation;
        }
    }
}
