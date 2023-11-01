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
        public int DistanceCrossed { get; private set; }
        public DateTime LastActivity { get; private set; }

        public Session(long tourId, long touristId, PositionSimulator location, SessionStatus sessionStatus, int distanceCrossed, DateTime lastActivity)
        {
            TourId = tourId;
            TouristId = touristId;
            Location = location;
            SessionStatus = sessionStatus;
            DistanceCrossed = distanceCrossed;
            LastActivity = lastActivity;

            Validate();

        }

        private void Validate()
        {
            if (DistanceCrossed <= 0) throw new ArgumentException("Invalid length");
            if (!DateTime.TryParse(LastActivity.ToString(), out _)) throw new ArgumentException("Invalid date and time");
        }
    }
}
