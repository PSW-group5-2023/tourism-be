using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IGuestUserService
    {
        Result<PagedResult<GuestUserDto>> GetPaged(int page, int pagedSize);        
        Result Delete(int id);
    }
}
