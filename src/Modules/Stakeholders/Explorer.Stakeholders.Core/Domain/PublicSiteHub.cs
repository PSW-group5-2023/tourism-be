using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.API.Dtos;

namespace Explorer.Stakeholders.Core.Domain
{
    public class PublicSiteHub : Hub
    {

        public async Task SendPublicKeyPointNotification(PublicTourKeyPointDto publicKeyPoint, string status)
        {
            await Clients.All.SendAsync("ReceivePublicKeyPointNotification", publicKeyPoint);
        }     
        public async Task SendPublicFacilityNotification(PublicFacilityDto publicFacility, string status)
        {
            await Clients.All.SendAsync("ReceivePublicFacilityNotification", publicFacility);
        }
    }
}
