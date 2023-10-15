using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class TourPreferencesDto
    { 
        public long UserId { get; set; }
        public int DifficultyLevel { get; set; }
        public Dictionary<TransportationType, int> TransportationRate { get; set; }
        public List<string> Tags { get; set; }
    }
}
public enum TransportationType
{
    Walking,
    Bicycle,
    Car,
    Boat
}
