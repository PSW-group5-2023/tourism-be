using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public enum TourStatus
    {
        DRAFT = 1,
        NOT_STARTED,
        ACTIVE,
        FINISHED,
        CANCELED
    }

    public enum TourDifficulty
    {
        BEGINNER = 1,
        INTERMEDIATE,
        ADVANCED,
        PRO
    }
    public class TourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string Tags { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public List<int> Equipment { get; set; }
        public TourDto()
        {
            this.Equipment = new List<int>();
        }
    }
}
