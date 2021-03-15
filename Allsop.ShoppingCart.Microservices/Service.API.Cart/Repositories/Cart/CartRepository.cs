using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.API.Cart.Infrastructure;

namespace Service.API.Cart.Repositories.Cart
{
    public class CartRepository: ICartRepository
    {
        private readonly CartDbContext _context;

        public CartRepository(CartDbContext context)
        {
            this._context = context;
        }
        
        public App.Support.Common.Models.Cart GetCartByAccountId(string accountId)
        {
            return this._context.Carts.Include("CartItems").FirstOrDefault(c => c.AccountId == Guid.Parse(accountId));
        }

        public async Task<App.Support.Common.Models.Cart> InsertCart(App.Support.Common.Models.Cart cart)
        {
            await this._context.Carts.AddAsync(cart);
            await this._context.SaveChangesAsync();
            return cart;
        }

        public void RemoveEmptyCart(App.Support.Common.Models.Cart cart)
        {
            if(IsEmptyCart(cart)) DeleteCart(cart);
        }

        public bool IsEmptyCart(App.Support.Common.Models.Cart cart)
        {
            var count = cart.CartItems.Count;
            return count == 0 || cart.CartItems.All(cartItem => cartItem.Quantity <= 0);
        }

        public async void DeleteCart(App.Support.Common.Models.Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }
        
        public async Task<App.Support.Common.Models.Cart> UpdateCart(App.Support.Common.Models.Cart cart)
        {
            var tempCart = _context.Carts.FirstOrDefault(c => c.Id == cart.Id);
            if (tempCart == null)
            {
                await this._context.Carts.AddAsync(cart);
            }
            await this._context.SaveChangesAsync();
            return cart;
        }
    }
}