using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class JoinRequestDto
    {
        public long ClubId { get; set; }
        public long UserId { get; set; }
        public Status RequestStatus { get; set; }
        public bool RequestDirection { get; set; }   // 0 is for guest -> owner direction

    }
}

public enum Status
{
    Pending,
    Accepted,
    Declined
}
