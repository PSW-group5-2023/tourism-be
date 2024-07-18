using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.Rating
{
    public class TourRating : Entity
    {
        public long PersonId { get; init; }
        public long TourId { get; init; }
        public int Mark { get; private set; }
        public string Comment { get; private set; }
        public DateTime DateOfVisit { get; private set; }
        public DateTime DateOfCommenting { get; private set; }
        public List<Uri> Images { get; private set; }

        public TourRating(long personId, long tourId, int mark, string comment, DateTime dateOfVisit, DateTime dateOfCommenting, List<Uri> images)
        {
            PersonId = personId;
            TourId = tourId;
            Mark = mark;
            Comment = comment;
            DateOfVisit = dateOfVisit;
            DateOfCommenting = dateOfCommenting;
            Images = images;
            Validate();
        }

        private void Validate()
        {
            if (Mark < 1 || Mark > 5) throw new ArgumentException("Invalid Mark");
            if (string.IsNullOrWhiteSpace(Comment)) throw new ArgumentException("Invalid Comment");
            if (string.IsNullOrWhiteSpace(DateOfVisit.ToString()) || (GetMilliseconds(DateOfVisit) > GetMilliseconds(DateTime.UtcNow))) throw new ArgumentException("Invalid DateOfVisit");
            if (string.IsNullOrWhiteSpace(DateOfCommenting.ToString()) || (GetMilliseconds(DateOfCommenting) > GetMilliseconds(DateTime.UtcNow))) throw new ArgumentException("Invalid DateOfCommenting");
            //if (Images.Count == 0) throw new ArgumentException("Invalid Images");
        }

        private long GetMilliseconds(DateTime date)
        {
            long milliseconds = date.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds;
        }
    }
}
