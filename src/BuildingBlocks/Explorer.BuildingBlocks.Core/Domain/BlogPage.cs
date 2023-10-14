using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.BuildingBlocks.Core.Domain
{
    public enum BlogState
    {
        Draft,
        Published,
        Closed
    }
    public class BlogPage : Entity
    {
        public string Title { get; init; }
        public string? Description { get; init; }
        public DateTime? CreationDate { get; init; }
        public BlogState? Status { get; init; }

        public BlogPage(string title, string? description, DateTime? creationDate,BlogState? status)
        {
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid title.");
            Title = title;
            Description = description;
            CreationDate = creationDate;
            Status = status;
        }
        public BlogPage() { }

    }
}
