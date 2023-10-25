using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Explorer.Tours.Core.Domain
{ 
    public enum TourProblemPriority
    {
        LOW,
        MEDIUM,
        HIGH
    }
    public enum TourProblemCategory
    {
        BOOKING,
        ITINERARY,
        PAYMENT,
        TRANSPORTATION,
        GUIDE_SERVICES,
        OTHER
    }
    public class TourProblem : Entity
    {
        public long TouristId { get; init; }
        public long TourId { get; init; }
        public TourProblemCategory Category { get; init; }
        public TourProblemPriority Priority { get; init; }
        public string Description { get; init; }
        public DateTime Time { get; init; }

        public TourProblem(long touristId,long tourId, TourProblemCategory category, TourProblemPriority priority, string description, DateTime time)
        {
            TouristId = touristId;
            TourId = tourId;
            Category = category;
            Priority = priority;
            Description = description;
            Time = time;
            Validate();
        }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Category.ToString())) throw new ArgumentException("Invalid Category.");
            if (string.IsNullOrWhiteSpace(Priority.ToString())) throw new ArgumentException("Invalid Priority.");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description.");
            if (string.IsNullOrWhiteSpace(Time.ToString())) throw new ArgumentException("Invalid Time.");
        }
    }
}