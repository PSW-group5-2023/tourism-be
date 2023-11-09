using Explorer.Stakeholders.Core.Domain;
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
    public class BoughtItemRepository : IBoughtItemRepository
    {
        private readonly ToursContext _dbContext;

        public BoughtItemRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BoughtItem AddToCart(BoughtItem item)
        {
            _dbContext.BoughtItems.Add(item);
            _dbContext.SaveChanges();

            return item;

        }
        public List<Tour> GetItemsByUserId(long userId)
        {
            List<BoughtItem> boughtItems = new List<BoughtItem>();
            List<Tour> tours = new List<Tour>();

            foreach(BoughtItem item in _dbContext.BoughtItems)
            {
                if (item.UserId == userId) boughtItems.Add(item);
            }

            foreach(var item in boughtItems) 
            {
                tours.Add(_dbContext.Tour.Find(item.TourId));
            }

            return tours;
        }

        public void UpdateItem(long userId, long itemId)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(long tourId, long userId)
        {
            var item = _dbContext.BoughtItems.Where(item => item.TourId == tourId && item.UserId == userId).FirstOrDefault();
            _dbContext.BoughtItems.Remove(item);
            _dbContext.SaveChanges();
        }

        public void GetItemToUpdate(long userId, long tourId)
        {
            var itemToUpdate = _dbContext.BoughtItems.Where(item => item.UserId == userId && item.TourId == tourId && !item.IsUsed).FirstOrDefault();
            typeof(BoughtItem).GetProperty("IsUsed").SetValue(itemToUpdate, true);


            try
            {
                if (itemToUpdate != null)
                {
                    _dbContext.BoughtItems.Update(itemToUpdate);
                    _dbContext.SaveChanges();
                }

            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }
        }


    }
}
