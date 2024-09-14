using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Equipment;
using Microsoft.IdentityModel.Tokens;


namespace Explorer.Tours.Core.Domain.Tours
{
    public class Tour : Entity
    {
        public string Name { get; private set; }
        public string Description { get; init; }
        public TourDifficulty Difficulty { get; init; }
        public List<string> Tags { get; init; }
        public TourStatus Status { get; private set; }
        public double Price { get; init; }
        public int AuthorId { get; init; }
        public List<Equipment.Equipment> Equipment { get; init; }
        public double DistanceInKm { get; init; }
        public DateTime? ArchivedDate { get; private set; }
        public DateTime? PublishedDate { get; private set; }
        public List<TourDuration> Durations { get; private set; }
        public List<Checkpoint> Checkpoints { get; private set; }
        public List<Uri>? Images { get; private set; }

        public Tour(string name, string description, TourDifficulty difficulty, List<string> tags, TourStatus status, double price, int authorId, double distanceInKm, DateTime? archivedDate, DateTime? publishedDate, List<TourDuration> durations)
        {
            Name = name;
            Description = description;
            Difficulty = difficulty;
            Tags = tags;
            Status = status;
            Price = price;
            AuthorId = authorId;
            DistanceInKm = distanceInKm;
            ArchivedDate = archivedDate;
            PublishedDate = publishedDate;
            Durations = durations;
            Equipment = new List<Equipment.Equipment>();
            Checkpoints = new List<Checkpoint>();
            if (Status == TourStatus.TouristMade)
            {
                TouristTourValidation();
            }
            Images = new List<Uri>();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description");
            if (int.TryParse(Difficulty.ToString(), out _)) throw new ArgumentException("Invalid tour difficulty.");
            if (Tags.IsNullOrEmpty()) throw new ArgumentException("Not enough Tags");
            if (Status != TourStatus.Draft) throw new ArgumentException("Tour is not in draft mode, so it cant be published");
            if (Price < 0) throw new ArgumentException("Invalid Price");
            if (DistanceInKm < 0) throw new ArgumentException("Invalid distance");
            if (Checkpoints.Count < 2) throw new ArgumentException("Not enough Key Points");
            if (Durations.IsNullOrEmpty()) throw new ArgumentException("Invalid durations");

            foreach(var duration in Durations)
            {
                if (duration.TimeInSeconds < 0) throw new ArgumentException("Invalid duration TimeInSeconds in Durations");
                if(int.TryParse(duration.Transportation.ToString(), out _)) throw new ArgumentException("Invalid duration Transportation in Durations");
            }
        }

        private void TouristTourValidation()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (Durations.Count == 0) throw new ArgumentException("Not enough Durations");
            if (Status != TourStatus.TouristMade) throw new ArgumentException("Tourist didn't make this tour");
        }

        public void Publish(int userId)
        {
            Validate();
            IsAuthor(userId);

            PublishedDate = DateTime.UtcNow;
            Status = TourStatus.Published;
        }

        public void Archive(int userId)
        {
            if (Status != TourStatus.Published) throw new ArgumentException("Tour must be published in order to be archived");
            IsAuthor(userId);

            ArchivedDate = DateTime.UtcNow;
            Status = TourStatus.Archived;
        }

        private void IsAuthor(int userId)
        {
            if (AuthorId != userId) throw new UnauthorizedAccessException("User is not the author of the tour");
        }

        public void UpdateTouristTour(Tour tour)
        {
            Name = tour.Name;
            Checkpoints = tour.Checkpoints;
            Durations = tour.Durations;
        }
    }

    public enum TourStatus
    {
        Draft,
        Published,
        Archived,
        TouristMade
    }

    public enum TourDifficulty
    {
        Beginner,
        Intermediate,
        Advanced,
        Pro
    }
}
