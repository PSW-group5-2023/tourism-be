using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos
{
    public class ChallengeDto
    {
        public int Id { get; set; }
        public int AdministratorId { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
