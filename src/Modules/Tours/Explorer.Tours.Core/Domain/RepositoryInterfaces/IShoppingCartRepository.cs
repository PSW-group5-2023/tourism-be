using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetByUserId(long userId);
        void ClearCart(long userId);
        ShoppingCart AddToCart(long cartId, long tourId);
        void DeleteCartItem(long userId, long itemId);
    }
}
