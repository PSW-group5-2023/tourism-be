using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain.Followers
{
    public class NotifiationHub : Hub
    {
        public async Task SendNewFollowerNotification(string follower, string status, long followedId)
        {
            await Clients.All.SendAsync("ReceiveNewFollowerNotification", follower, status, followedId);
        }
        public async Task SendFollowerMessageNotification(long recipientId, string senderUsername)
        {
            await Clients.All.SendAsync("ReceiveFollowerMessageNotification", recipientId, senderUsername);
        }
    }
}
