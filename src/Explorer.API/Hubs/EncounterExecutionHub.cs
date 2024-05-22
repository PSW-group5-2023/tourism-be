using Explorer.Encounters.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Explorer.API.Hubs
{
    [Authorize(Policy = "touristPolicy")]
    public class EncounterExecutionHub : Hub<IEncounterExecutionClient>
    {
        private readonly IEncounterService _encounterService;

        public EncounterExecutionHub(IEncounterService encounterService)
        {
            _encounterService = encounterService;
        }

        public async Task StartSocialEncounter(long encounterId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"social-encounter({encounterId})");

            var userId = Context.GetHttpContext().User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.StartEncounter(encounterId, long.Parse(userId.Value));

            if (result.IsFailed)
            {
                await Clients.Caller.Error(result.Errors.ToString());
                return;
            }

            await Clients.Caller.StartSocialEncounter(encounterId);
        }

        public async Task UpdateLocation(double latitude, double longitude, long encounterId)
        {
            var userId = Context.GetHttpContext().User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var socialEncounterStatus = _encounterService.UpdateLocation(latitude, longitude, encounterId, long.Parse(userId.Value));

            if (socialEncounterStatus.IsFailed)
            {
                await Clients.Caller.Error(socialEncounterStatus.Errors.ToString());
                return;
            }

            await Clients.Caller.GetNumberOfActiveTourists(socialEncounterStatus.Value.NumberOfTourists);

            if (socialEncounterStatus.Value.Completed)
            {
                await Clients.Group($"social-encounter({encounterId})").CompleteSocialEncounter(encounterId);
            }
        }

        public async Task AbandonSocialEncounter(long encounterId)
        {
            var userId = Context.GetHttpContext().User.Claims.FirstOrDefault(c => c.Type.Equals("id"));
            var result = _encounterService.AbandonEncounter(encounterId, long.Parse(userId.Value));

            if (result.IsFailed)
            {
                await Clients.Caller.Error(result.Errors.ToString());
                return;
            }

            await Clients.Caller.AbandonSocialEncounter(encounterId);
        }
    }
}
