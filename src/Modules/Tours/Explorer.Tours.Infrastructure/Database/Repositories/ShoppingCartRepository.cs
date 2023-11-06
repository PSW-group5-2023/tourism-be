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
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ToursContext _dbContext;

        public ShoppingCartRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ShoppingCart AddToCart(long userId, long tourId)
        {
            var cart = _dbContext.ShoppingCarts.Include(x => x.ShoppingCartItems).Where(cart => cart.UserId == userId).FirstOrDefault();

            if (cart == null) cart = CreateNewCart(userId);
            if (cart.ShoppingCartItems.Select(item => item.TourId).Contains(tourId)) throw new Exception("Cannot add same tour twice!");

            var cartItem = new ShoppingCartItem(cart.Id,tourId);

            cart.ShoppingCartItems.Add(cartItem);
            _dbContext.SaveChanges();

            return cart;

        }

        public void ClearCart(long userId)
        {
            var cart = _dbContext.ShoppingCarts.Include(x => x.ShoppingCartItems).Where(cart => cart.UserId == userId).FirstOrDefault();

            if (cart == null) throw new KeyNotFoundException("Cart not found!");

            cart.ShoppingCartItems.Clear();
            _dbContext.SaveChanges();

        }

        public void DeleteCartItem(long userId, long itemId)
        {
            var cart = _dbContext.ShoppingCarts.Include(x => x.ShoppingCartItems).Where(cart => cart.UserId == userId).FirstOrDefault();
            if (cart == null) throw new KeyNotFoundException("Cart not found!");

            var item = cart.ShoppingCartItems.Where(item => item.Id == itemId).FirstOrDefault();
            if (item == null) throw new KeyNotFoundException("Cart item not found!");

            cart.ShoppingCartItems.Remove(item);
            _dbContext.SaveChanges();
        }

        public ShoppingCart GetByUserId(long userId)
        {
            var cart = _dbContext.ShoppingCarts.Include(x => x.ShoppingCartItems).ThenInclude(item => item.Tour).Where(cart => cart.UserId == userId).FirstOrDefault();
            if (cart == null) cart = CreateNewCart(userId);
            return cart;
        }

        private ShoppingCart CreateNewCart(long userId)
        {
            var cart = new ShoppingCart(userId);
            _dbContext.ShoppingCarts.Add(cart);
            _dbContext.SaveChanges();
            return cart;
        }
    }
}
