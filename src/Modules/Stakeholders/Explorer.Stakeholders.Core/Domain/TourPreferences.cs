using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core
{
    public class TourPreferences : Entity
    {
        public long UserId { get; init; }
        public int DifficultyLevel { get; init; }
        public Dictionary<TransportationType, int> TransportationRate { get; init; }
        public List<string> Tags { get; init; }

        public TourPreferences(long userId, int difficultyLevel, Dictionary<TransportationType, int> transportationRate, List<string> tags)
        {
            UserId = userId;
            DifficultyLevel = difficultyLevel;
            TransportationRate = transportationRate;
            Tags = tags;
            Validate();
        }

        public void Validate()
        {
            if (UserId == 0) throw new ArgumentException("Invalid UserId");
            if (DifficultyLevel < 1 || DifficultyLevel > 5) throw new ArgumentException("Invalid difficulty level");
            foreach(int rate in TransportationRate.Values)
            {
                if (rate < 0 || rate > 3) throw new ArgumentException("Invalid transportation rate");
            }
        }
    }
}

public enum TransportationType
{
    Walking,
    Bicycle,
    Car,
    Boat
}
