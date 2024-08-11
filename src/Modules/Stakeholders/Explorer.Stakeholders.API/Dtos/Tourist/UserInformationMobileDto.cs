using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos.Tourist
{
    public class UserInformationMobileDto
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

        public UserInformationMobileDto(string username, string role, string email)
        {
            Username = username;
            Role = role;
            Email = email;
        }
    }
}
