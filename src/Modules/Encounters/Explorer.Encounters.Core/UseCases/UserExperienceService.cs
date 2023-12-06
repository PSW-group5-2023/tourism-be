using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using FluentResults;

namespace Explorer.Encounters.Core.UseCases
{
    public class UserExperienceService : CrudService<UserExperienceDto, UserExperience>, IUserExperienceService
    {
        public UserExperienceService(ICrudRepository<UserExperience> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }
    }
}
