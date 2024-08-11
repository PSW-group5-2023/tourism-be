using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class RegisteredUserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public String Role { get; set; }

        public RegisteredUserDto(long id, string username, String role)
        {
            Id = id;
            Username = username;
            Role = role;
        }
    }
}
