namespace Explorer.Encounters.API.Dtos
{
    public class SocialEncounterStatus
    {
        public bool IsCompleted { get; set; }
        public List<long> Tourists { get; set; }

        public SocialEncounterStatus(bool isCompleted, List<long> tourists)
        {
            IsCompleted = isCompleted;
            Tourists = tourists;
        }
    }
}
