using AutoMapper;
using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Achievements.Core.Domain;
using Explorer.Achievements.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Core.UseCases
{
    public class AchievementService : CrudService<AchievementDto, Achievement>, IAchievementService
    {
        public IAchievementRepository _achievementRepository;
        public AchievementService(ICrudRepository<Achievement> crudRepository, IMapper mapper, IAchievementRepository achievementRepository) : base(crudRepository, mapper)
        {
            _achievementRepository = achievementRepository;
        }

        public Result<List<AchievementDto>> GetAllBaseAchievements()
        {
            return MapToDto(_achievementRepository.GetAllBaseAchievements());
        }

        public Result<List<AchievementDto>> GetAllComplexAchievements()
        {
            return MapToDto(_achievementRepository.GetAllComplexAchievements());
        }

        public Result<AchievementDto> CreateComplexAchievement(List<int> requiredAchievements)
        {
            try
            {
                var allComplexAchievements = _achievementRepository.GetAllComplexAchievements();
                Achievement? matchingAchievement = allComplexAchievements.FirstOrDefault(a => HaveSameItems(a.CraftingRecipe, requiredAchievements));
                if (matchingAchievement == null) throw new ArgumentException("There is no complex achievement with that recipe");

                return MapToDto(matchingAchievement);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        private static bool HaveSameItems(List<int> list1, List<int> list2)
        {
            var dict1 = list1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var dict2 = list2.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            return dict1.Count == dict2.Count && !dict1.Except(dict2).Any();
        }
    }
}
