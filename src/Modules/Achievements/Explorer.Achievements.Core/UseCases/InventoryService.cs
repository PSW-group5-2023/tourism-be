using AutoMapper;
using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Achievements.Core.Domain;
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
        public InventoryService(ICrudRepository<Inventory> crudRepository, IMapper mapper):base(crudRepository, mapper) 
        {
        }
        public Result<InventoryDto> AddAchievementToInventory(InventoryDto inventory, int achivementId)
        {
            if(!inventory.AchievementsId.Contains(achivementId))
                inventory.AchievementsId.Add(achivementId);
            Update(inventory);
            return inventory.ToResult();
        }
    }
}
