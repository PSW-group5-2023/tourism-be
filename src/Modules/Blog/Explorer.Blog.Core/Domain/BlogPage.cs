using Explorer.Blog.API.Dtos;
using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Blog.Core.Domain
{
    
    public class BlogPage : Entity
    {
        public string Title { get; init; }
        public string? Description { get; init; }
        public DateTime? CreationDate { get; init; }
        public BlogState? Status { get; init; }
        public long UserId {  get; init; }
        public List<Rating> Ratings { get; init; }
        


        public BlogPage(string title, string? description, BlogState? status, long userId, List<Rating> ratings)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Invalid title.");
            Title = title;
            Description = description;
            CreationDate = DateTime.UtcNow;
            Status = status;
            UserId = userId;
            Ratings = ratings;
        }
        public void AddRating()
        {
            //uraditi posle 
        }

    }
}

