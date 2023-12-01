using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Core.Domain
{
    public class LocationChallange : Challenge
    {
        public Uri Image {  get; init; }
        public double LatitudeImage { get; init; }
        public double LongitudeImage { get; init;}
        public double Range {  get; init; }

        public LocationChallange(int administratorId, string description, string name, ChallengeStatus status, ChallengeType type, double latitude, double longitude,
            Uri image, double latitudeImage, double longitudeImage, double range) : base(administratorId, description, name, status, type, latitude, longitude)
        {
            Image = image;
            LatitudeImage = latitudeImage;
            LongitudeImage = longitudeImage;
            Range = range;
        }
    }
}
