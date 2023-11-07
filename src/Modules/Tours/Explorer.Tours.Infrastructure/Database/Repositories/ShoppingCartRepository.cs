using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class ShoppingCartRepository : IBoughtItemRepository
    {
        private readonly ToursContext _dbContext;

        public ShoppingCartRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BoughtItem AddToCart(BoughtItem item)
        {
            _dbContext.BoughtItems.Add(item);
            _dbContext.SaveChanges();

            return item;

        }
        public List<BoughtItem> GetItemsByUserId(long userId)
        {
            List<BoughtItem> boughtItems = new List<BoughtItem>();

            foreach(BoughtItem item in _dbContext.BoughtItems)
            {
                if (item.UserId == userId) boughtItems.Add(item);
            }

            return boughtItems;
        }

        public void UpdateItem(long userId, long itemId)
        {
            throw new NotImplementedException();
        }

    }
}
