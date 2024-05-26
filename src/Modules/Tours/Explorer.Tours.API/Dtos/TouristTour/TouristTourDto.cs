using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.API.Dtos.Tour;

namespace Explorer.Tours.API.Dtos.TouristTour
{
    public class TouristTourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public double DistanceInKm { get; set; }
        public List<CheckpointDto> KeyPoints { get; set; }
    }
}
