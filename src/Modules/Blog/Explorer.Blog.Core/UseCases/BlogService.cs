using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.Domain;
using Explorer.Blog.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.UseCases
{
    public class BlogService:CrudService<BlogDto, BlogPage>,IBlogService
    {
        public IInternalBlogRepository _internalBlogRepository;
        public IBlogRepository _blogRepository;
        public BlogService(ICrudRepository<BlogPage> repository , IMapper mapper,IInternalBlogRepository internalBlogRepository,IBlogRepository blogRepository):base(repository,mapper) {
            _internalBlogRepository = internalBlogRepository;
            _blogRepository = blogRepository;
        }

        public Result<BlogDto> Get(int id)
        {
            try
            {
                
                var blog = _blogRepository.Get(id);
                var user = _internalBlogRepository.GetByUserId(blog.UserId);
                var result= MapToDto(blog);
                result.Username = user.Username;
                return result;
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }

            

        }
    }
}
