using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class TourStatistics : Entity
    {
        public long TourId { get; init; }
        public double NumberOfStats { get; init; }

        public TourStatistics(double numberOfStats)
        {
            NumberOfStats=numberOfStats;
        }
    }
}
