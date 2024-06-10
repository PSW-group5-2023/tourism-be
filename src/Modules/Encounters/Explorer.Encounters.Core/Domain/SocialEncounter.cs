namespace Explorer.Encounters.Core.Domain
{
    public class SocialEncounter : Encounter
    {
        public double RangeInMeters { get; init; }
        public int RequiredAttendance { get; init; }

        public SocialEncounter(long creatorId, string description, string name, EncounterStatus status, EncounterType type, double latitude, double longitude, long? checkpointId, int experiencePoints, bool isMandatory, long? achievementId, double rangeInMeters, int requiredAttendance) : base(creatorId, description, name, status, type, latitude, longitude, checkpointId, experiencePoints, isMandatory, achievementId)
        {
            RangeInMeters = rangeInMeters;
            RequiredAttendance = requiredAttendance;
            if (RangeInMeters < 1) throw new ArgumentException($"Invalid {nameof(RangeInMeters)}");
            if (RequiredAttendance < 1) throw new ArgumentException($"Invalid {nameof(RequiredAttendance)}");
        }

        public bool IsInRange(double latitude, double longitude)
        {
            int earthRadius = 6371000;

            // Convert latitude and longitude from degrees to radians
            var latitudeRad = ToRadians(Latitude);
            var longitudeRad = ToRadians(Longitude);
            var touristLatitudeRad = ToRadians(latitude);
            var touristLongitudeRad = ToRadians(longitude);

            // Calculate the differences
            double dlat = latitudeRad - touristLatitudeRad;
            double dlon = longitudeRad - touristLongitudeRad;

            // Haversine formula
            double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(latitudeRad) * Math.Cos(longitudeRad) * Math.Pow(Math.Sin(dlon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Calculate the distance
            double distance = earthRadius * c;

            return distance <= RangeInMeters;
        }

        private double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
