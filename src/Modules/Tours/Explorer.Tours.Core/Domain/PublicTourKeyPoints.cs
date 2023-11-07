using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class PublicTourKeyPoints : TourKeyPoint
    {
        public PublicTourKeyPointStatus Status { get; private set; }
        public int CreatorId { get; private set; } 
        public PublicTourKeyPoints(string name, string description, Uri image, double latitude, double longitude, PublicTourKeyPointStatus status, int creatorId, int? tourId = null) : base(name, description, image, latitude, longitude, tourId)
        {
            Status = status;
            CreatorId = creatorId;
        }


        public void ChangeStatus(PublicTourKeyPointStatus status)
        {
            Status = (PublicTourKeyPointStatus)status;
        }

        public enum PublicTourKeyPointStatus
        {
            Approved,
            Denied,
            Pending
        }
    }
}
