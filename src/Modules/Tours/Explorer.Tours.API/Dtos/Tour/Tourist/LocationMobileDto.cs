using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Tour.Tourist
{
    public class LocationMobileDto
    {
        public double Radius { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public LocationMobileDto() { }

        public LocationMobileDto(double radius, double latitude, double longitude)
        {
            Radius = radius;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
