﻿using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;

namespace Explorer.Tours.Core.Domain.Statistics
{
    public class TourStatistics : ValueObject
    {
        public long TourId { get; set; }
        public double NumberOfStats { get; set; }

        [JsonConstructor]
        public TourStatistics(long tourId, double numberOfStats)
        {
            TourId = tourId;
            NumberOfStats = numberOfStats;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TourId;
            yield return NumberOfStats;
        }
    }
}
