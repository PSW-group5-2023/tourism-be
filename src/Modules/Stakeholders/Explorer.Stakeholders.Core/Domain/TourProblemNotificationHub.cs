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
        public async Task SendTourProblemMessageNotification(int recipientId)
        {
            await Clients.All.SendAsync("ReceiveTourProblemMessageNotification", recipientId);
        }
    }
}
