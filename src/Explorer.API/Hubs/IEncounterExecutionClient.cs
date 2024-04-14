namespace Explorer.API.Hubs
{
    public interface IEncounterExecutionClient
    {
        Task StartSocialEncounter(long encounterId);
        Task GetNumberOfActiveTourists(long numberOfActiveTours);
        Task CompleteSocialEncounter(long encounterId);
        Task Error(string message);
        Task AbandonSocialEncounter(long encounterId);
    }
}