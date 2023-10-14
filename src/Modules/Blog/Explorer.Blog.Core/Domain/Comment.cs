using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Blog.Core.Domain
{
    public class Comment : Entity
    {
        public string Username { get; init; }
        public DateTime CreationDate { get; init; }
        public string Description { get; init; }
        public DateTime LastEditDate { get; init; }
        public long BlogId { get; init; }

        public Comment(string username, DateTime creationDate, string description, DateTime lastEditDate, long blogId)
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
            if (string.IsNullOrWhiteSpace(Description)) throw new ArgumentException("Invalid Description");
        }
    }
}
