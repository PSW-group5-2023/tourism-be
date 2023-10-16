using Explorer.BuildingBlocks.Core.Domain;
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
        public TourDifficulty Difficulty { get; init; }
        public string Tags { get; init; }
        public TourStatus Status { get; init; }
        public double Price { get; init; }

        public Tour(string name, string description, TourDifficulty difficulty, string tags, TourStatus status, double price)
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
        }
    }
}
