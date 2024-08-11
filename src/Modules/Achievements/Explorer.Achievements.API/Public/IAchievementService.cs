using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Dtos.Tourist;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.API.Public
{
    public interface IAchievementService
    {
        Result<AchievementDto> Create(AchievementDto achievement);
        Result Delete(int id);
        Result<AchievementDto> Get(int id);
        Result<PagedResult<AchievementDto>> GetPaged(int page, int pageSize);
        Result<List<AchievementDto>> GetAllBaseAchievements();
        Result<List<AchievementDto>> GetAllComplexAchievements();
        Result<AchievementModuleAchievementMobileDto> GetComplexAchievement(int id);
        Result<List<AchievementWithFullRecipeMobileDto>> GetAllComplexAchievementsWithFullRecipes();
        Result<AchievementWithFullRecipeMobileDto> GetComplexAchievementWithFullRecipe(int id);
        Result<AchievementDto> CreateComplexAchievement(List<int> requiredAchievements);
        Result<AchievementModuleAchievementMobileDto> GetMobile(int id);
    }
}
