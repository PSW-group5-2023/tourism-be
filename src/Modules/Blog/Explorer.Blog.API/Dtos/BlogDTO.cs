

using System.Text.Json.Serialization;

namespace Explorer.Blog.API.Dtos
{
    public enum BlogState
        {
            Draft,
            Published,
            Closed,
            Famous,
            Active
        }
    public class BlogDto
    {
        
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public BlogState? Status { get; set; }
        public string Username { get; set; }
        public List<RatingDto> Ratings { get; set; }
        


    }
}
