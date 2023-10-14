using Explorer.Blog.API.Dtos;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.API.Public
{
    public interface IBlogService
    {
        Result<PagedResult<BlogDTO>> GetPaged(int page, int pageSize);
        Result<BlogDTO> Create(BlogDTO blog);
        Result<BlogDTO> Update(BlogDTO blog);
        Result Delete(int id);
    }
}
