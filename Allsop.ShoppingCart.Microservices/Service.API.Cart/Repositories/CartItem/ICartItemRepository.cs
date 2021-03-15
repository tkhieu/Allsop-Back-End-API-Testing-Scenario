using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.API.Cart.Repositories.CartItem
{
    public interface ICartItemRepository
    {
        ICollection<App.Support.Common.Models.CartItem> GetCartItemsByCartId(string cartId);
        Task<App.Support.Common.Models.CartItem> InsertCartItem(App.Support.Common.Models.CartItem cartItem);
        Task<App.Support.Common.Models.CartItem> UpdateCartItem(App.Support.Common.Models.CartItem cartItem);
        void DeleteCartItem(App.Support.Common.Models.CartItem cartItem);
    }
}