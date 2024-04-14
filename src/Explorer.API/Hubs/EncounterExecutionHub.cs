using Explorer.Encounters.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Explorer.API.Hubs
{
    [Authorize(Policy = "touristPolicy")]
    public class EncounterExecutionHub : Hub<IEncounterExecutionClient>
    {
        public async Task StartSocialEncounter(long encounterId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"social-encounter({encounterId})");
            await Clients.Caller.StartSocialEncounter(encounterId);
        }

        public async Task UpdateLocation(double latitude, double longitude, long encounterId, IEncounterService service)
        {
            var userId = Context.GetHttpContext().User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var socialEncounterStatus = service.UpdateLocation(latitude, longitude, encounterId, long.Parse(userId.Value));
            if (socialEncounterStatus.IsFailed) {
                await Clients.Caller.Error(socialEncounterStatus.Errors.ToString());
                Context.Abort();
                return;
            }
            await Clients.Caller.GetNumberOfActiveTourists(socialEncounterStatus.Value.Tourists.Count);
            if (socialEncounterStatus.Value.IsCompleted)
            {
                await Clients.Group($"social-encounter({encounterId})").CompleteSocialEncounter(encounterId);
            }
        }

        public async Task AbandonSocialEncounter(long encounterId, IEncounterService service)
        {
            var userId = Context.GetHttpContext().User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            service.AbandonEncounter(encounterId, long.Parse(userId.Value));
            await Clients.Caller.AbandonSocialEncounter(encounterId);
            Context.Abort();
        }
    }
}
