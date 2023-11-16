using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class PublicSiteHub : Hub
    {

        public async Task SendPublicKeyPointNotification(string publicKeyPoint, string status, int creatorId)
        {
            await Clients.All.SendAsync("ReceivePublicKeyPointNotification", publicKeyPoint, status, creatorId);

        } 
        public async Task SendPublicFacilityNotification(string publicFacility, string status,int creatorId)
        {
            await Clients.All.SendAsync("ReceivePublicFacilityNotification", publicFacility, status, creatorId);
        }
    }
}
