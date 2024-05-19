namespace Explorer.API.Hubs
{
    public interface IEncounterExecutionClient
    {
        Task StartSocialEncounter(long encounterId);
        Task GetNumberOfActiveTourists(int numberOfActiveTours);
        Task CompleteSocialEncounter(long encounterId);
        Task Error(string message);
        Task AbandonSocialEncounter(long encounterId);
    }
}