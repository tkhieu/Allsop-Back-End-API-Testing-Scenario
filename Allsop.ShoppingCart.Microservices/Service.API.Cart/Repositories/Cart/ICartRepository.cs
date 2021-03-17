using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.API.Cart.Repositories.Cart
{
    public interface ICartRepository
    {
        App.Support.Common.Models.Cart GetCartByAccountId(string accountId);
        void RemoveEmptyCart(App.Support.Common.Models.Cart cart);
        bool IsEmptyCart(App.Support.Common.Models.Cart cart);
        void DeleteCart(App.Support.Common.Models.Cart cart);
        Task<App.Support.Common.Models.Cart> InsertOrUpdateCart(App.Support.Common.Models.Cart cart);
    }
}