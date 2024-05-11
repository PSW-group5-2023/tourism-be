using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Core.Domain
{
    public class Achievement : Entity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public Uri Icon { get; init; }
        public RarityCategories Rarity { get; init; }
        public long KeypointId { get; init; }
        public long AuthorId { get; init; }

        public Achievement(string name, string description, Uri icon, RarityCategories rarity, long keypointId, long authorId)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Rarity = rarity;
            KeypointId = keypointId;
            AuthorId = authorId;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description");
           
        }

        public enum RarityCategories
        {
            Common,
            Rare,
            Epic,
            Legendary

        }
    }
}
