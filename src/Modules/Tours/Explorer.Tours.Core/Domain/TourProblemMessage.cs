using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.Domain
{
    public class TourProblemMessage : ValueObject
    {
        public long UserId { get; init; }
        public DateTime CreationTime { get; init; }
        public string Description { get; init; }

        [JsonConstructor]
        public TourProblemMessage(long userId, DateTime creationTime, string description)
        {
            UserId = userId;
            CreationTime = creationTime;
            Description = description;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return CreationTime;
            yield return Description;
        }

    }
}
