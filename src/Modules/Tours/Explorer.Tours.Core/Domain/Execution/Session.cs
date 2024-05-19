using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Sessions.DomainEvents;

namespace Explorer.Tours.Core.Domain.Sessions
{
    public enum SessionStatus
    {
        ACTIVE,
        COMPLETED,
        ABANDONED
    }

    public class Session : EventSourcedAggregate
    {
        public long TourId { get; private set; }
        public long TouristId { get; private set; }
        public long LocationId { get; private set; }
        public SessionStatus SessionStatus { get; private set; }
        public int Transportation { get; private set; }
        public int DistanceCrossedPercent { get; private set; }
        public DateTime LastActivity { get; private set; }
        public List<CompletedKeyPoint> CompletedKeyPoints { get; private set; }

        public Session(long tourId, long touristId, long locationId, SessionStatus sessionStatus, int transportation, int distanceCrossedPercent, DateTime lastActivity, List<CompletedKeyPoint> completedKeyPoints)
        {
            TourId = tourId;
            TouristId = touristId;
            LocationId = locationId;
            SessionStatus = sessionStatus;
            Transportation = transportation;
            DistanceCrossedPercent = distanceCrossedPercent;
            LastActivity = lastActivity;
            CompletedKeyPoints = completedKeyPoints;

            Validate();
        }

        private void Validate()
        {
            if (int.TryParse(SessionStatus.ToString(), out _)) throw new ArgumentException("Invalid SessionStatus");
            if (Transportation < 0 || Transportation > 2) throw new ArgumentException("Invalid transportation");
           // if (DistanceCrossed <= 0) throw new ArgumentException("Invalid length");
            if (!DateTime.TryParse(LastActivity.ToString(), out _) 
                || (GetMilliseconds(LastActivity) > GetMilliseconds(DateTime.UtcNow))) throw new ArgumentException("Invalid LastActivity");
            
            foreach(var keyPoint in CompletedKeyPoints)
            {
                if (GetMilliseconds(keyPoint.CompletionTime) > GetMilliseconds(DateTime.UtcNow)) throw new ArgumentException("Invalid keyPoint CompletionTime in CompletedKeyPoints");
            }
        }

        private long GetMilliseconds(DateTime date)
        {
            long milliseconds = date.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }

        public bool ValidForTouristComment()
        {
            DateTime sevenDaysAgo = DateTime.Now.AddDays(-7);
            if (LastActivity >= sevenDaysAgo && DistanceCrossedPercent >= 35)
                return true;

            return false;
        }

        public CompletedKeyPoint AddCompletedKeyPoint(int keyPointId)
        {
            var completedKeyPoint = new CompletedKeyPoint(keyPointId, DateTime.UtcNow);
            var completeKeyPointCheck = CompletedKeyPoints.FirstOrDefault(ckp => ckp.KeyPointId == keyPointId);
            if (completeKeyPointCheck == null)
            {
                CompletedKeyPoints.Add(completedKeyPoint);
                Causes(new KeyPointCompleted(this.Id, DateTime.UtcNow));
            }

            return completedKeyPoint;
        }

        public void Create()
        {
            Causes(new SessionCreated(this.Id, DateTime.UtcNow));
        }

        public void UpdateLocation(double latitude, double longitude)
        {
            Causes(new LocationUpdated(this.Id, latitude, longitude));
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version++;
        }

        private void When(KeyPointCompleted keyPointCompleted)
        {

        }

        private void When(SessionCreated sessionCreated)
        {

        }

        private void When(LocationUpdated locationUpdated)
        {

        }
    }
}
