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

    }
}
