using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.Domain
{

    public class Rating : ValueObject
    {
        public long UserId { get; init; }
        public DateTime CreationDate { get; init; }
        public int RatingValue { get; init; }

        [JsonConstructor]
        public Rating(long userId, DateTime creationDate, int ratingValue)
        {
            UserId = userId;
            CreationDate = creationDate;
            RatingValue = ratingValue;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
