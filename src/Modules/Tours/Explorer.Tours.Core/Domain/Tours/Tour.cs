using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.IdentityModel.Tokens;

namespace Explorer.Tours.Core.Domain.Tours
{

    public class Tour : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public TourDifficulty Difficulty { get; init; }
        public List<string> Tags { get; init; }
        public TourStatus Status { get; init; }
        public double Price { get; init; }
        public int AuthorId { get; init; }
        public int[] Equipment { get; init; }
        public double DistanceInKm { get; init; }
        public DateTime? ArchivedDate { get; set; }
        public DateTime? PublishedDate { get; private set; }
        public List<TourDuration> Durations { get; init; }
        public List<TourKeyPoint> KeyPoints { get; init; }

        public Tour(string name, string description, TourDifficulty difficulty, List<string> tags, TourStatus status, double price, int authorId, int[] equipment, double distanceInKm, DateTime? archivedDate, DateTime? publishedDate, List<TourDuration> durations)
        {
            Name = name;
            Description = description;
            Difficulty = difficulty;
            Tags = tags;
            Status = status;
            Price = price;
            AuthorId = authorId;
            Equipment = equipment;
            DistanceInKm = distanceInKm;
            ArchivedDate = archivedDate;
            PublishedDate = publishedDate;
            Durations = durations;
            KeyPoints = new List<TourKeyPoint>();

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description");
            if (Price < 0) throw new ArgumentException("Invalid price");
            if (Tags.IsNullOrEmpty()) throw new ArgumentException("Invalid Tags");
        }
    }

    public enum TourStatus
    {
        Draft,
        Published,
        Archived
    }

    public enum TourDifficulty
    {
        Beginner,
        Intermediate,
        Advanced,
        Pro
    }
}
