using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class ClubDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public Uri ClubPicture { get; set; }
    }
}