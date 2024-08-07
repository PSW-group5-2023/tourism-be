using AutoMapper;
using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Dtos.Tourist;
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

        public Result<AchievementModuleAchievementMobileDto> GetMobile(int id)
        {
            var achievementsBase = _achievementRepository.Get(id);
            AchievementModuleAchievementMobileDto achievementTouristMobileDto = new AchievementModuleAchievementMobileDto(MapToDto(achievementsBase));
            achievementTouristMobileDto.Rarity = achievementsBase.Rarity.ToString();
            return achievementTouristMobileDto;
        }

        public Result<AchievementDto> GetComplexAchievement(int id)
        {
            var result = _achievementRepository.GetComplexAchievement(id);

            var dto = new AchievementDto
            {
                Id = (int)result.Value.Id,
                Name = result.Value.Name,
                Description = result.Value.Description,
                Icon = result.Value.Icon,
                Rarity = (int)result.Value.Rarity,
                CraftingRecipe = result.Value.CraftingRecipe
            };

            return Result.Ok(dto);
        }

        public Result<List<AchievementWithFullRecipeMobileDto>> GetAllComplexAchievementsWithFullRecipes()
        {
            var allAchievementsResult = _achievementRepository.GetAllComplexAchievements();
        
            var mappedAchievements = allAchievementsResult.Select(a => new AchievementWithFullRecipeMobileDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Icon = a.Icon,
                Rarity = (int)a.Rarity,
                CraftingRecipe = a.CraftingRecipe.Select(id =>
                {
                    var recipeAchievement = _achievementRepository.Get(id);
                    return new AchievementDto
                    {
                        Id = (int)recipeAchievement.Id,
                        Name = recipeAchievement.Name,
                        Description = recipeAchievement.Description,
                        Icon = recipeAchievement.Icon,
                        Rarity = (int)recipeAchievement.Rarity,
                        CraftingRecipe = recipeAchievement.CraftingRecipe
                    };
                }).ToList()
            }).ToList();

            return Result.Ok(mappedAchievements);
        }

        public Result<AchievementWithFullRecipeMobileDto> GetComplexAchievementWithFullRecipe(int id)
        {
            var craftResult = _achievementRepository.GetComplexAchievement(id);

            if (!craftResult.IsSuccess)
            {
                return Result.Fail<AchievementWithFullRecipeMobileDto>(craftResult.Errors);
            }

            var craft = craftResult.Value;

            var mappedCraft = new AchievementWithFullRecipeMobileDto
            {
                Id = craft.Id,
                Name = craft.Name,
                Description = craft.Description,
                Icon = craft.Icon,
                Rarity = (int)craft.Rarity,
                CraftingRecipe = craft.CraftingRecipe.Select(recipeId =>
                {
                    var recipeAchievementResult = _achievementRepository.Get(recipeId);  
                    
                    var recipeAchievement = recipeAchievementResult;

                    return new AchievementDto
                    {
                        Id = (int)recipeAchievement.Id,
                        Name = recipeAchievement.Name,
                        Description = recipeAchievement.Description,
                        Icon = recipeAchievement.Icon,
                        Rarity = (int)recipeAchievement.Rarity,
                        CraftingRecipe = recipeAchievement.CraftingRecipe
                    };
                }).Where(dto => dto != null).ToList()
            };

            return Result.Ok(mappedCraft);
        }






    }
}
