using AutoMapper;
using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Internal;
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
    public class InventoryMobileInternalService : CrudService<InventoryDto, Inventory>, IInventoryMobileInternalService
    {
        public InventoryMobileInternalService(ICrudRepository<Inventory> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }

        public Result DeleteByUserId(int userId)
        {
            try
            {
                var inventory = CrudRepository.GetPaged(0, 0).Results.Where(x => x.UserId == userId).FirstOrDefault();
                CrudRepository.Delete(inventory.Id);
                return Result.Ok();
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }
    }
}
