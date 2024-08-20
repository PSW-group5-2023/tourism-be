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
        private IAchievementService _achievementService;
        private IInventoryRepository _inventoryRepository;
        public InventoryService(ICrudRepository<Inventory> crudRepository, IMapper mapper, IAchievementService achievementService, IInventoryRepository inventoryRepository):base(crudRepository, mapper) 
        {
            _achievementService = achievementService;
            _inventoryRepository = inventoryRepository;
        }
        public Result<InventoryDto> AddAchievementToInventory(int userId, int achivementId)
        {
            //if(!inventory.AchievementsId.Contains(achivementId))
            Inventory inventory= _inventoryRepository.GetByUserId(userId).Value;
            inventory.AchievementsId.Add(achivementId);
            _inventoryRepository.Update(inventory);
            return MapToDto(inventory).ToResult();
        }

        public Result<InventoryDto> AddComplexAchievementToInventory(int userId, List<int> requiredAchievemements)
        {
            var complexAchievement = _achievementService.CreateComplexAchievement(requiredAchievemements);

            return AddAchievementToInventory(userId, complexAchievement.Value.Id);
        }

        public Result<InventoryDto> GetByUserId(int userId)
        { 
            return MapToDto(_inventoryRepository.GetByUserId(userId).Value);
        }
       
    }
}
