using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class MessageNotificationHub : Hub
    {
        public async Task SendFollowerMessageNotification(long recipientId, string senderUsername)
        {
            await Clients.All.SendAsync("ReceiveFollowerMessageNotification", recipientId, senderUsername);
        }
    }
}