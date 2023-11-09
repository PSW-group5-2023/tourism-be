using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public.Identity;
using Explorer.Stakeholders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases.Identity
{
    public class FollowerService : CrudService<FollowerDto, Follower>, IFollowerService
    {
        public FollowerService(ICrudRepository<Follower> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }
    }
}
