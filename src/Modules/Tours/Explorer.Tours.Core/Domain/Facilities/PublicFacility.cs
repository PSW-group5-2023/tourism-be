namespace Explorer.Tours.Core.Domain.Facilities
{
    public class PublicFacility : Facility
    {

        public PublicFacilityStatus Status { get; private set; }
        public int CreatorId { get; init; }


        public PublicFacility(string name, string description, Uri image, FacilityCategory category, double latitude, double longitude, PublicFacilityStatus status, int creatorId) : base(name, description, image, category, latitude, longitude)
        {
            Status = status;
            CreatorId = creatorId;

            Validate();
        }

        private void Validate()
        {
            if (int.TryParse(Status.ToString(), out _)) throw new ArgumentException("Invalid Status");
        }

        public void ChangeStatus(PublicFacilityStatus status)
        {
            Status = status;
        }

        public enum PublicFacilityStatus
        {
            Approved,
            Denied,
            Pending
        }
    }
}
