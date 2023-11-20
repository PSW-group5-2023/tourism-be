using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Core.Domain
{
    public class Encounter : Entity
    {
        public int AdministratorId { get; init; }
        public int TouristId { get; init; }
        public string Description { get; init; }
        public string Name { get; init; }
        public double ExpiriencePoints { get; init; }
        public EncounterStatus Status { get; init; }
        public EncounterType Type { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; set; }

        public Encounter(int administratorId, int touristId, string description, string name, double expiriencePoints, EncounterStatus status, EncounterType encounterType, double latitude, double longitude)
        {
            AdministratorId = administratorId;
            TouristId = touristId;
            Description = description;
            Name = name;
            ExpiriencePoints = expiriencePoints;
            Status = status;
            Type = encounterType;
            Latitude = latitude;
            Longitude = longitude;

            Validate();
        }
        private void Validate()
        {
            if (AdministratorId == 0) throw new ArgumentException("Invalid AdministratorId");
            if (TouristId == 0) throw new ArgumentException("Invalid TouristId");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description");
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (ExpiriencePoints < 0) throw new ArgumentException("Invalid ExpiriencePoints");
            if (Status == EncounterStatus.Active) throw new ArgumentException("Invalid encounter status");
            if (Latitude is > 90 or < -90) throw new ArgumentException("Invalid latitude");
            if (Longitude is > 180 or < -180) throw new ArgumentException("Invalid longitude");
        }
    }
    public enum EncounterStatus
    {
        Draft,
        Active,
        Archived
    }
    public enum EncounterType
    {
        Social,
        Location,
        Misc
    }
}
