using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.Achievements.API.Internal;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Dtos.Tourist;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserInformationService : CrudService<UserInformationDto, User>, IUserInformationService
    {
        private readonly IInventoryMobileInternalService _inventoryMobileInternalService;
        public UserInformationService(ICrudRepository<User> userRepository, IMapper mapper, IInventoryMobileInternalService inventoryMobileInternalService) : base(userRepository, mapper)
        {
            _inventoryMobileInternalService = inventoryMobileInternalService;
        }

        public Result<UserInformationMobileDto> GetMobile(int userId)
        {
            var user = CrudRepository.Get(userId);
            if(user.AvatarImage==null) 
                return new UserInformationMobileDto(user.Username, user.Role.ToString(), user.Email);
            return new UserInformationMobileDto(user.Username,user.Role.ToString(), user.Email,user.AvatarImage.ToString());
        }

        public Result<PagedResult<UserInformationDto>> Join(Result<PagedResult<UserInformationDto>> users, Result<PagedResult<UserInformationDto>> persons)
        {
            foreach (var user in users.Value.Results) 
            {
                foreach (var person in persons.Value.Results)
                {
                    if (user.UserId == person.UserId)
                    {
                        user.Email=person.Email;  
                    }
                }
            }
            users.Value.Results.RemoveAll(u => u.Role.Equals("Administrator"));
            return users;
        }
        public Result Delete(int userId)
        {
            try
            {
                CrudRepository.Delete(userId);
                _inventoryMobileInternalService.DeleteByUserId(userId);
                return Result.Ok();
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<UserInformationMobileDto> ChangeAvatarImage(string image, int userId)
        {
            try 
            {
                var user = CrudRepository.Get(userId);
                user.ChangeAvatarImage(image);
                CrudRepository.Update(user);
                return new UserInformationMobileDto(user.Username, user.Role.ToString(), user.Email,user.AvatarImage.ToString()).ToResult();
            }
            catch(Exception e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }
    }
}
