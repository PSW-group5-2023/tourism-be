using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class UserProfileDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Uri ProfilePic { get; set; }
        public string Biography { get; set; }
        public string Motto { get; set; }
    }
}
