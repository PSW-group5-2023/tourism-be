using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string Tags { get; set; }
        public int Status { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }
        public int[] Equipment { get; set; }
        public DateTime? ArchivedDate { get; set; }
    }
}
