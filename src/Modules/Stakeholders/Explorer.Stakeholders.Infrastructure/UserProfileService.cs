using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserProfileService : BaseService<UserProfileDto, UserProfile>, IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileService(IUserProfileRepository userProfileRepository, IMapper mapper) : base(mapper) 
        {
            _userProfileRepository = userProfileRepository;
        }

        public Result<UserProfileDto> GetById(int id)
        {
            return MapToDto(_userProfileRepository.GetById(id));
        }

        public Result<UserProfileDto> Update(UserProfileDto userProfile, int id)
        {
            UserProfileDto updated = MapToDto(_userProfileRepository.Update(MapToDomain(userProfile), id));
            return updated;
        }
    }
}
