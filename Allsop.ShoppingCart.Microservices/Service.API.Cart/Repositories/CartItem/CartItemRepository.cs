using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.API.Cart.Infrastructure;

namespace Service.API.Cart.Repositories.CartItem
{
    public class CartItemRepository: ICartItemRepository
    {
        private readonly CartDbContext _context;

        public CartItemRepository(CartDbContext context)
        {
            _context = context;
        }
        
        public ICollection<App.Support.Common.Models.CartService.CartItem> GetCartItemsByCartId(string cartId)
        {
            return _context.CartItems.Where(ci => ci.CartId == cartId).ToList();
        }

        public async Task<App.Support.Common.Models.CartService.CartItem> InsertCartItem(App.Support.Common.Models.CartService.CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<App.Support.Common.Models.CartService.CartItem> UpdateCartItem(App.Support.Common.Models.CartService.CartItem cartItem)
        {
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<bool> DeleteCartItem(App.Support.Common.Models.CartService.CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}