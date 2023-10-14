using Explorer.Stakeholders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public string Comment { get; set; }
        public Person Person { get; set; }
        public DateTime DateOfVisit { get; set; }
        public DateTime DateOfCommenting { get; set; }
        public List<Uri> Images { get; set; }
    }
}
