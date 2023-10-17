using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public enum TourProblemPriority
    {
        LOW,
        MEDIUM,
        HIGH
    }
    public class TourProblemDto
    {
        public int Id { get; set; }
        public long TourId { get; set; }
        public string Category { get; set; }
        public TourProblemPriority Priority { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
    }
}
