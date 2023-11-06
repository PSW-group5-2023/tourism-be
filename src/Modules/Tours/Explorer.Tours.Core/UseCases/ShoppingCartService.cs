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
    public class ShoppingCartService : BaseService<ShoppingCartDto,ShoppingCart>, IShoppingCartService
    {
        private IShoppingCartRepository shoppingCartRepository;

        public ShoppingCartService(IMapper mapper,IShoppingCartRepository shoppingCartRepository) : base(mapper)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public Result<ShoppingCartDto> AddToCart(long cartId, long tourId)
        {
            return base.MapToDto(shoppingCartRepository.AddToCart(cartId, tourId));
        }

        public Result ClearCart(long userId)
        {
            try
            {
                shoppingCartRepository.ClearCart(userId);
            }
            catch(KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }

            return Result.Ok();
        }

        public Result<ShoppingCartDto> GetByUserId(long userId)
        { 
            return base.MapToDto(shoppingCartRepository.GetByUserId(userId));
        }

        public Result DeleteCartItem(long userId,long cartId)
        {
            try
            {
                shoppingCartRepository.DeleteCartItem(userId, cartId);
            }
            catch (KeyNotFoundException e) 
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }

            return Result.Ok();
        }
    }
}
