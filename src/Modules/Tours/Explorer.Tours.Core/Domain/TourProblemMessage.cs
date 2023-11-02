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
        public DateTime CreationDate { get; init; }
        public string Description { get; init; }

        [JsonConstructor]
        public TourProblemMessage(long userId, DateTime creationDate, string description)
        {
            UserId = userId;
            CreationDate = creationDate;
            Description = description;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return Description;
            yield return CreationDate;
        }

    }
}
