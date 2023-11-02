

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
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public BlogState? Status { get; set; }

        
    }
}
