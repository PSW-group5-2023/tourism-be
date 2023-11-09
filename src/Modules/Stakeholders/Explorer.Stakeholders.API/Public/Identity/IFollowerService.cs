using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public.Identity
{
    public interface IFollowerService
    {
        public Result<FollowerDto> Get(int id);
        public Result<FollowerDto> Create(FollowerDto dto);
        public Result Delete(int id);
    }
}
