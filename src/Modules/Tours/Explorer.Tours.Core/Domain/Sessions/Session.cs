using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.Sessions
{
    public enum SessionStatus
    {
        ACTIVE,
        COMPLETED,
        ABANDONED
    }

    public class Session : Entity
    {
        public long TourId { get; private set; }
        public long TouristId { get; private set; }
        public PositionSimulator Location { get; private set; }
        public SessionStatus SessionStatus { get; private set; }
        public int DistanceCrossedPercent { get; private set; }
        public DateTime LastActivity { get; private set; }
        public List<CompletedKeyPoint> CompletedKeyPoints { get; private set; }

        public Session(long tourId, long touristId, PositionSimulator location, SessionStatus sessionStatus, int distanceCrossedPercent, DateTime lastActivity, List<CompletedKeyPoint> completedKeyPoints)
        {
            TourId = tourId;
            TouristId = touristId;
            Location = location;
            SessionStatus = sessionStatus;
            DistanceCrossedPercent = distanceCrossedPercent;
            LastActivity = lastActivity;
            CompletedKeyPoints = completedKeyPoints;

            Validate();
        }

        private void Validate()
        {
           // if (DistanceCrossed <= 0) throw new ArgumentException("Invalid length");
            if (!DateTime.TryParse(LastActivity.ToString(), out _)) throw new ArgumentException("Invalid date and time");
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
            }

            return completedKeyPoint;
        }
    }
}
