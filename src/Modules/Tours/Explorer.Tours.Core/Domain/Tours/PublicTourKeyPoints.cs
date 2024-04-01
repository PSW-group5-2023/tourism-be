namespace Explorer.Tours.Core.Domain.Tours
{
    public class PublicTourKeyPoints : TourKeyPoint
    {
        public PublicTourKeyPointStatus Status { get; private set; }
        public int CreatorId { get; private set; }
        public PublicTourKeyPoints(string name, string description, Uri image, double latitude, double longitude, PublicTourKeyPointStatus status, int creatorId, int? positionInTour, long? tourId = null) : base(name, description, image, latitude, longitude, positionInTour, tourId)
        {
            Status = status;
            CreatorId = creatorId;
        }


        public void ChangeStatus(PublicTourKeyPointStatus status)
        {
            Status = status;
        }

        public enum PublicTourKeyPointStatus
        {
            Approved,
            Denied,
            Pending
        }
    }
}
