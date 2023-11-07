using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IBoughtItemRepository
    {
        List<Tour> GetItemsByUserId(long userId);
        BoughtItem AddToCart(BoughtItem item);

        void DeleteItem(long tourId, long userId);
    }
}
