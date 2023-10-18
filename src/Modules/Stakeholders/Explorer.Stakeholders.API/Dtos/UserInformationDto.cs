using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Stakeholders.API.Dtos
{
    public class UserInformationDto
    {
        public String Username { get; set; }
        public String Email { get; set; }
        public String Role { get; set; }

        public UserInformationDto(string username, string email, String role)
        {
            Username = username;
            Email = email;
            Role = role;
        }

        public UserInformationDto()
        {
        }
    }
}
