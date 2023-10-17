using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IUserProfileService
    {
        public Result<UserProfileDto> GetById(int id);
        public Result<UserProfileDto> Update(UserProfileDto userProfile, int id);
    }
}
