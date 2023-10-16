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
        public int WalkingRate { get; init; }
        public int BicycleRate { get; init; }
        public int CarRate { get; init; }
        public int BoatRate { get; init; }
        public List<string> Tags { get; init; }

        public TourPreferences(long userId, int difficultyLevel, int walkingRate, int bicycleRate, int carRate, int boatRate, List<string> tags)
        {
            UserId = userId;
            DifficultyLevel = difficultyLevel;
            WalkingRate = walkingRate;
            BicycleRate = bicycleRate;
            CarRate = carRate;
            BoatRate = boatRate;
            Tags = tags;
            Validate();
        }

        public void Validate()
        {
            if (UserId == 0) throw new ArgumentException("Invalid UserId");
            if (DifficultyLevel < 1 || DifficultyLevel > 5) throw new ArgumentException("Invalid difficulty level");
        }
    }
}

