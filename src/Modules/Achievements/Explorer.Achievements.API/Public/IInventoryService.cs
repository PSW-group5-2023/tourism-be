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
    public interface IInventoryService
    {
        Result<InventoryDto> Create(InventoryDto inventory);
        Result Delete(int id);
        Result<InventoryDto> Get(int id);
        Result<InventoryDto> Update(InventoryDto inventory);
        Result<PagedResult<InventoryDto>> GetPaged(int page, int pageSize);
        Result<InventoryDto> AddAchievementToInventory(int userId, int achivementId);
        Result<InventoryDto> AddComplexAchievementToInventory(int userId, List<int> requiredAchievemements);
        Result<InventoryDto> GetByUserId(int userId);
    }
}
