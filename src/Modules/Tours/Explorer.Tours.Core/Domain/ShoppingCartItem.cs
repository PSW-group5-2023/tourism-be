using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class ShoppingCartItem : Entity
    {   
        public long ShoppingCartId { get; init; }
        public long TourId { get; init; }
        public Tour Tour { get; set; }

        public ShoppingCartItem(long shoppingCartId, long tourId)
        {
            ShoppingCartId = shoppingCartId;
            TourId = tourId;
        }

    }
}
