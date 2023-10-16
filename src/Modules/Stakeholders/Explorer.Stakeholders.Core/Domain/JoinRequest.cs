using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Explorer.Stakeholders.Core.Domain;


public class Request : Entity
{
    public long ClubId { get; private set; }
    public long UserId { get; private set; }
    public Status RequestStatus { get; private set; }

    public Request(long clubId, long userId, Status status)
    {
        if (clubId == 0) throw new ArgumentException("Invalid UserId");
        if (userId == 0) throw new ArgumentException("Invalid UserId");

        ClubId = clubId;
        UserId = userId;
        RequestStatus = status;

    }

}
public enum Status
{
    Pending,
    Accepted,
    Declined
}