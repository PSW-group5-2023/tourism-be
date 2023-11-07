using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases
{
    public class ShoppingCartService : BaseService<BoughtItemDto,BoughtItem>, IBoughtItemService
    {
        private IBoughtItemRepository shoppingCartRepository;

        public ShoppingCartService(IMapper mapper,IBoughtItemRepository shoppingCartRepository) : base(mapper)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }


        public Result<List<BoughtItemDto>> GetItemsByUserId(long userId)
        {
            return base.MapToDto(shoppingCartRepository.GetItemsByUserId(userId));
        }

        public Result Create(List<BoughtItemDto> items)
        {
            {
                try
                {
                    foreach(var item in items) 
                    shoppingCartRepository.AddToCart(MapToDomain(item));
                }
                catch (Exception e)
                {
                    return Result.Fail(FailureCode.NotFound).WithError(e.Message);
                }

                return Result.Ok();
            }
        }

    }
}
