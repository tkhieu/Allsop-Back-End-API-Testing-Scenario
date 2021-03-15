using System.Collections.Generic;

namespace Service.API.Cart.Repositories.Cart
{
    public interface ICartRepository
    {
        
        App.Support.Common.Models.Cart GetCartByAccountId(string accountId);
        void InsertCart(App.Support.Common.Models.Cart cart);
        void DeleteCart(string cartId);
        void UpdateCart(App.Support.Common.Models.Cart cart);
        void Save();
    }
}