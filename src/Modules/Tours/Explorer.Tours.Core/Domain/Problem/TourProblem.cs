using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.Problem
{
    public class TourProblem : Entity
    {
        public long TouristId { get; init; }
        public long TourId { get; init; }
        public TourProblemCategory Category { get; init; }
        public TourProblemPriority Priority { get; init; }
        public string Description { get; init; }
        public DateTime Time { get; init; }
        public bool IsSolved { get; private set; }
        public List<TourProblemMessage> Messages { get; init; }
        public DateTime? Deadline { get; private set; }


        public TourProblem(long touristId, long tourId, TourProblemCategory category, TourProblemPriority priority, string description, DateTime time, bool isSolved, List<TourProblemMessage> messages)
        {
            TouristId = touristId;
            TourId = tourId;
            Category = category;
            Priority = priority;
            Description = description;
            Time = time;
            IsSolved = isSolved;
            Messages = messages;

            Validate();
        }
        public TourProblemMessage CreateMessage(long senderId, long recipientId, DateTime time, string description, bool isRead)
        {
            TourProblemMessage message = new TourProblemMessage(senderId, recipientId, time, description, isRead);
            Messages.Add(message);
            return message;
        }
        public void Validate()
        {
            if (int.TryParse(Category.ToString(), out _)) throw new ArgumentException("Invalid Category.");
            if (int.TryParse(Priority.ToString(), out _))throw new ArgumentException("Invalid Priority.");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description.");
            if (string.IsNullOrWhiteSpace(Time.ToString()) || GetMilliseconds(Time) > GetMilliseconds(DateTime.UtcNow)) throw new ArgumentException("Invalid Time.");

            foreach(var message in Messages)
            {
                if (GetMilliseconds(message.CreationTime) > GetMilliseconds(DateTime.UtcNow)) throw new ArgumentException("Invalid message CreationTime in Messages");
                if (String.IsNullOrWhiteSpace(message.Description)) throw new ArgumentException("Invalid message Description in Messages");
            }
        }

        private long GetMilliseconds(DateTime date)
        {
            long milliseconds = date.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }
        public void GiveDeadline(DateTime deadline)
        {
            if (deadline > DateTime.Now)
                Deadline = deadline;
            else
                throw new ArgumentException("Invalid date!");
        }
        public void CloseProblem()
        {
            IsSolved = true;
        }
    }

    public enum TourProblemPriority
    {
        LOW = 0,
        MEDIUM,
        HIGH
    }
    public enum TourProblemCategory
    {
        BOOKING = 0,
        ITINERARY,
        PAYMENT,
        TRANSPORTATION,
        GUIDE_SERVICES,
        OTHER
    }
}