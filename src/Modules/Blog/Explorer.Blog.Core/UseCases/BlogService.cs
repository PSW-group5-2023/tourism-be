using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.Domain;
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
        public BlogService(ICrudRepository<BlogPage> repository , IMapper mapper,IInternalBlogRepository internalBlogRepository):base(repository,mapper) {
            _internalBlogRepository = internalBlogRepository;
        }

        public Result<BlogDto> Get(int id)
        {

            var result = CrudRepository.Get(id);
            var user=_internalBlogRepository.GetByUserId(result.UserId);
            BlogDto blog = new BlogDto
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Status = result.Status,
                Username = user.Username
            };


            return blog;
            
        }
    }
}
