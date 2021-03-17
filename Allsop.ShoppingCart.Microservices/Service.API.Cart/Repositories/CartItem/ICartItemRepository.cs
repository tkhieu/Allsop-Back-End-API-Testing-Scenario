using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.API.Cart.Repositories.CartItem
{
    public interface ICartItemRepository
    {
        ICollection<App.Support.Common.Models.CartService.CartItem> GetCartItemsByCartId(string cartId);
        Task<App.Support.Common.Models.CartService.CartItem> InsertCartItem(App.Support.Common.Models.CartService.CartItem cartItem);
        Task<App.Support.Common.Models.CartService.CartItem> UpdateCartItem(App.Support.Common.Models.CartService.CartItem cartItem);
        void DeleteCartItem(App.Support.Common.Models.CartService.CartItem cartItem);
    }
}