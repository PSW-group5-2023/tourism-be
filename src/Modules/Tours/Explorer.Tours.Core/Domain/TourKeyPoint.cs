using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Options;

namespace Explorer.Tours.Core.Domain
{
    public class TourKeyPoint : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Image { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }

        public TourKeyPoint(string name, string description, string image, double latitude, double longitude)
        {
            Name = name;
            Description = description;
            Image = image;
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
