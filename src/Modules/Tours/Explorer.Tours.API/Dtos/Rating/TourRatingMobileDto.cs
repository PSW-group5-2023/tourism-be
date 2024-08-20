using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Rating
{
    public class TourRatingMobileDto
    {
        public long UserId { get; set; }
        public long TourId { get; set; }
        public int Mark { get; set; }
        public string Comment { get; set; }
        public DateTime DateOfCommenting { get; set; }

    }
}
