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
    public class InventoryService:CrudService<InventoryDto,Inventory>,IInventoryService
    {
        public IAchievementService _achievementService;
        public InventoryService(ICrudRepository<Inventory> crudRepository, IMapper mapper, IAchievementService achievementService):base(crudRepository, mapper) 
        {
            _achievementService = achievementService;
        }
        public Result<InventoryDto> AddAchievementToInventory(InventoryDto inventory, int achivementId)
        {
            inventory.AchievementsId.Add(achivementId);
            Update(inventory);
            return inventory.ToResult();
        } 

        public Result<InventoryDto> AddComplexAchievementToInventory(InventoryDto inventory, List<int> requiredAchievemements)
        {
            var complexAchievement = _achievementService.CreateComplexAchievement(requiredAchievemements);

            return AddAchievementToInventory(inventory, complexAchievement.Value.Id);
        }

        public Result<InventoryDto> GetByUserId(int userId)
        {
            var item = CrudRepository.GetPaged(0, 0).Results.FirstOrDefault(x => x.UserId == userId);
            if (item == null) return Result.Fail(FailureCode.InvalidArgument).WithError("User not found.");
            return MapToDto(item);
        }
    }
}
