using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class Tour : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Difficulty { get; init; }
        public string Tags { get; init; }
        public TourStatus Status { get; private set; }
        public double Price { get; init; }
        public int AuthorId { get; init; }
        public int[] Equipment { get; init; }
        public DateTime? ArchivedDate{ get; set; }

        public Tour(string name, string description, string difficulty, string tags, TourStatus status, double price, int authorId, int[] equipment, DateTime? archivedDate)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name.");
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Invalid Description.");
            if (string.IsNullOrWhiteSpace(tags)) throw new ArgumentException("Invalid Tags.");
            if (string.IsNullOrWhiteSpace(price.ToString())) throw new ArgumentException("Invalid Price.");

            Name = name;
            Description = description;
            Difficulty = difficulty;
            Tags = tags;
            Status = status;
            Price = price;
            AuthorId = authorId;
            Equipment = equipment;
            ArchivedDate = archivedDate;
        }

        /*public Tour Archive()
        {
            this.Status = TourStatus.Archived;
            this.ArchivedDate = DateTime.Now;
            return this;
        }*/
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
