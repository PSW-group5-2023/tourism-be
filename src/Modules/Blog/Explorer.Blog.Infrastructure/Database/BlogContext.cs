using Explorer.Blog.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Blog.Infrastructure.Database;

public class BlogContext : DbContext
{
    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<BlogPage> Blogs { get; set; }
    public BlogContext(DbContextOptions<BlogContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blog");

        ConfigureBlog(modelBuilder);
    }

    private static void ConfigureBlog(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Comment>()
            .HasOne<BlogPage>()
            .WithOne()
            .HasForeignKey<Comment>(s => s.BlogId);*/


        /*modelBuilder.Entity<Comment>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<Comment>(s => s.UserId);*/
    }
}