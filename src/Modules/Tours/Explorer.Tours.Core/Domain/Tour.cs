using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{

    public enum TourStatus
    {
        DRAFT = 1,
        NOT_STARTED,
        ACTIVE,
        FINISHED,
        CANCELED
    }

    public enum TourDifficulty
    {
        BEGINNER = 1,
        INTERMEDIATE,
        ADVANCED,
        PRO
    }

    public class Tour : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Difficulty { get; init; }
        public string Tags { get; init; }
        public string Status { get; init; }
        public double Price { get; init; }
        public int AuthorId { get; init; }

        public List<int> Equipment { get; init; }
        public Tour(string name, string description, string difficulty, string tags, string status, double price, int authorId)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name.");
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Invalid Description.");
            if (string.IsNullOrWhiteSpace(tags)) throw new ArgumentException("Invalid Tags.");
            if (string.IsNullOrWhiteSpace(price.ToString())) throw new ArgumentException("Invalid Price.");
            if (string.IsNullOrWhiteSpace(status)) throw new ArgumentException("Invalid Status.");
            if (string.IsNullOrWhiteSpace(price.ToString())) throw new ArgumentException("Invalid Price.");
            if (string.IsNullOrWhiteSpace(authorId.ToString())) throw new ArgumentException("Invalid AuthorId.");

            Name = name;
            Description = description;
            Difficulty = difficulty;
            Tags = tags;
            Status = status;
            Price = price;
            this.Equipment = new List<int>();
        }
    }
}
