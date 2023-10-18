using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserInformationService : CrudService<UserInformationDto, User>, IUserInformationService
    {
        public UserInformationService(ICrudRepository<User> userRepository, IMapper mapper) : base(userRepository, mapper)
        { }

    }
}
