using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Equipment;
using Microsoft.IdentityModel.Tokens;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class Tour : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public TourDifficulty Difficulty { get; init; }
        public TourStatus Status { get; private set; }
        public List<string> Tags { get; init; }
        public double Price { get; init; }
        public long AuthorId { get; init; }
        public double DistanceInKm { get; init; }
        public DateTime? ArchivedDate { get; private set; }
        public DateTime? PublishedDate { get; private set; }
        public List<Checkpoint> Checkpoints { get; init; }
        public List<TourDuration> Durations { get; init; }
        public int[] Equipment { get; init; }
        public Uri? Image { get; init; }

        public Tour(string name, string description, TourDifficulty difficulty, List<string> tags, TourStatus status, double price, int authorId, double distanceInKm, DateTime? archivedDate, DateTime? publishedDate, int[] equipment, List<TourDuration> durations, Uri? image = null)
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
            Checkpoints = new List<Checkpoint>();
            Equipment = equipment;
            Image = image ?? new Uri("https://www.flimslaax.com/fileadmin/Daten/0Flims_Laax_Bilder/3-Outdoor/3-2-Wandern/3-2-1-Wanderwege/flims_laax_falera_wanderwege2.jpg");
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description");
            if (Price < 0) throw new ArgumentException("Invalid Price");
            if (Tags.IsNullOrEmpty()) throw new ArgumentException("Not enough Tags");
            if (Checkpoints.Count < 2) throw new ArgumentException("Not enough Key Points");
            if (Durations.IsNullOrEmpty()) throw new ArgumentException("Invalid duration");
            if (Status == TourStatus.Published) throw new ArgumentException("Tour is already published");
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
