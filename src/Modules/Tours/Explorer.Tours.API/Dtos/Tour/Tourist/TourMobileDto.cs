using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Tour.Tourist
{
    public class TourMobileDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CheckpointDto> Checkpoints { get; set; }
        public List<string>? Images { get; set; }
        public double Price { get; set; }
        //public string Location { get; set; }
        public double Rating { get; set; }

    }
 }
