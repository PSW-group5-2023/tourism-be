using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Execution.Tourist
{
    public class SessionMobileDto
    {
        public long Id { get; set; }
        public long TourId { get; set; }
        public long TouristId { get; set; }
        public int SessionStatus { get; set; }
        public List<CompletedKeyPointDto> CompletedKeyPoints { get; set; }
    }
}
