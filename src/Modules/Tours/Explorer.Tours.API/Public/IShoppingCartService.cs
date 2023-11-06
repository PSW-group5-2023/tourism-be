using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public
{
    public interface IShoppingCartService
    {
        Result<ShoppingCartDto> GetByUserId(long userId);
        Result<ShoppingCartDto> AddToCart(long cartId, long tour);
        Result ClearCart(long userId);
        Result DeleteCartItem(long userId, long cartId);
    }
}
