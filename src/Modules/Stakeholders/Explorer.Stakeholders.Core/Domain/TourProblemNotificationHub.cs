using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class TourProblemNotificationHub : Hub
    {
        public async Task SendProblemMessageNotification(string problemMessage, int recipientId, string senderUsername)
        {
            await Clients.All.SendAsync("ReceiveProblemMessageNotification", problemMessage, recipientId, senderUsername);
        }
        public async Task SendDeadlineNotification(string authorUsername, long tourId, DateTime deadline)
        {
            await Clients.All.SendAsync("ReceiveDeadlineNotification", authorUsername, tourId, deadline);
        }
    }
}
