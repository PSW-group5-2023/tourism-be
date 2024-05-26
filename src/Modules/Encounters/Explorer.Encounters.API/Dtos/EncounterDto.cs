namespace Explorer.Encounters.API.Dtos
{
    public class EncounterDto
    {
        public long Id { get; set; }
        public long CreatorId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Type { get; set; }
        public int ExperiencePoints { get; set; }
        public bool IsMandatory { get; set; }
        public Uri? Image { get; set; }
        public double? LocationLatitude { get; set; }
        public double? LocationLongitude { get; set; }
        public double? RangeInMeters { get; set; }
        public long? CheckpointId { get; set; }
        public int? RequiredAttendance { get; set; }
    }
}
