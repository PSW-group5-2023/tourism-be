using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Encounters.Core.UseCases
{
    public class UserExperienceService : CrudService<UserExperienceDto, UserExperience>, IUserExperienceService
    {
        IUserExperienceRepository _userExperienceRepository;
        public UserExperienceService(ICrudRepository<UserExperience> crudRepository, IUserExperienceRepository userExperienceRepository, IMapper mapper) : base(crudRepository, mapper)
        {
            _userExperienceRepository = userExperienceRepository;
        }

        public Result<UserExperienceDto> AddXP(long id, int xp)
        {
            var userExperience = CrudRepository.Get(id);
            userExperience.AddXP(xp);
            userExperience.CalculateLevel();
            CrudRepository.Update(userExperience);
            UserExperienceDto dto = new UserExperienceDto();
            dto.UserId = userExperience.UserId;
            dto.XP = userExperience.XP;
            dto.Id = userExperience.Id;
            dto.Level = userExperience.Level;
            return dto;

        }

        public Result<UserExperienceDto> Create(long userId)
        {
            try
            {
                var result = _userExperienceRepository.Create(MapToDomain(new UserExperienceDto()
                {
                    UserId = userId,
                    Level = 1,
                    XP = 0,
                }));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<UserExperienceDto> GetByUserId(long userId)
        {
            var userExperience = _userExperienceRepository.GetByUserId(userId);
            return MapToDto(userExperience);
        }
    }
}
