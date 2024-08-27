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
            Inventory inventory= _inventoryRepository.GetByUserId(userId).Value;
            inventory.AddAchievementToInventory(achivementId);
            _inventoryRepository.Update(inventory);
            return MapToDto(inventory).ToResult();
        }

        public Result<InventoryDto> AddComplexAchievementToInventory(int userId, List<int> requiredAchievemements)
        {
            try
            {
                var complexAchievement = _achievementService.CreateComplexAchievement(requiredAchievemements);
                Inventory inventory = _inventoryRepository.GetByUserId(userId).Value;
                bool required = HasRequiredAchievements(requiredAchievemements, inventory);
                if (required)
                {
                    inventory.AddComplexAchievementToInventory(complexAchievement.Value.Id,requiredAchievemements);
                    _inventoryRepository.Update(inventory);
                    return MapToDto(inventory).ToResult();
                }
                else
                    throw new ArgumentException("There are no required achievements for complex achievement");
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        private bool HasRequiredAchievements(List<int> requiredAchievemements, Inventory inventory)
        {
            bool required = true;
            foreach (var achievement in requiredAchievemements)
            {
                if (!inventory.Achievements.ContainsKey(achievement) || inventory.Achievements[achievement] < 1)
                {
                        required = false;
                        break;
                }
            }
            return required;
        }

        public Result<InventoryDto> GetByUserId(int userId)
        { 
            return MapToDto(_inventoryRepository.GetByUserId(userId).Value);
        }
       
    }
}
