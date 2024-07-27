using Explorer.Achievements.API.Dtos;
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
        Result<AchievementDto> CreateComplexAchievement(List<int> requiredAchievements);
        Result<AchievementTouristMobileDto> GetMobile(int id);
    }
}
