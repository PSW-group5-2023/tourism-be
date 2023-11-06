using Explorer.Blog.API.Dtos;
using Explorer.Blog.Core.Domain;
using Explorer.Blog.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.Infrastructure.Database.Repositories
{
    public class BlogRepository:IBlogRepository
    {
        public readonly BlogContext _dbContext;

        public BlogRepository(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BlogPage? Get(int id)
        {
            var blog=_dbContext.Blogs.FirstOrDefault(b => b.Id == id);
            return blog;
        }

        public List<BlogPage> GetAll()
        {
            var query = _dbContext.Blogs;
            return query.ToList();
        }
    }
}
