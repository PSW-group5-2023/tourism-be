using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.Domain
{
    public class Comment : Entity
    {
        public string Username { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Description { get; private set; }
        public DateTime? LastEditDate { get; private set; }
        public long BlogId { get; private set; }

        public Comment(string username, DateTime creationDate, string description, DateTime? lastEditDate, long blogId)
        {
            Username = username;
            CreationDate = creationDate;
            Description = description;
            LastEditDate = lastEditDate;
            BlogId = blogId;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Username)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Name");
        }
    }
}
