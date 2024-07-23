using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class GuestUserDto
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public List<int> AchievementsId { get; set; }
        public int Status { get; set; }

        public GuestUserDto() 
        {
            AchievementsId = new List<int>();
        }
    }
}
