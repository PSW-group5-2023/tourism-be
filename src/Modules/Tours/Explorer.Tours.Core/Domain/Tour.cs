using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.IdentityModel.Tokens;

namespace Explorer.Tours.Core.Domain
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
        public Tour(string name, string description, TourDifficulty difficulty, List<string> tags, TourStatus status, double price, int authorId, int[] equipment)
        {
            Validate();

            Name = name;
            Description = description;
            Difficulty = difficulty;
            Tags = tags;
            Status = status;
            Price = price;
            AuthorId = authorId;
            Equipment = equipment;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description");
            if (Price < 0) throw new ArgumentException("Invalid price");
            if (Tags.IsNullOrEmpty()) throw new ArgumentException("Invalid Tags");
        }

        public enum TourStatus
        {
            Draft,
            Published,
            Archived
        }

        public enum TourDifficulty
        {
            // Still unknown
            /*BEGINNER = 1,
            INTERMEDIATE,
            ADVANCED,
            PRO*/
        }
    }
}
