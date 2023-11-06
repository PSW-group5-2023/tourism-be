using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class ShoppingCart : Entity
    {

        public long UserId { get; init; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart()
        {
            
        }

        public ShoppingCart(long userId)
        {
            UserId = userId;
        }
    }
}
