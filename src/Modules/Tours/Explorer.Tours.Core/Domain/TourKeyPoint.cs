﻿using System;
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
        public Uri Image { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }

        public TourKeyPoint(string name, string description, string image, double latitude, double longitude)
        {
            Name = name;
            Description = description;
            Image = new Uri(image, UriKind.Absolute);
            Latitude = latitude;
            Longitude = longitude;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid name");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid description");
            if (Latitude is > 90 or < -90) throw new ArgumentException("Invalid latitude");
            if (Longitude is > 180 or < -180) throw new ArgumentException("Invalid longitude");
        }

    }
}
