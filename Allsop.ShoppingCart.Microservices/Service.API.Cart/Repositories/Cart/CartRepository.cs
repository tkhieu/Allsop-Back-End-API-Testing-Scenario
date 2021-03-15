using System;
using System.Linq;
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
            return this._context.Carts.FirstOrDefault(c => c.AccountId == Guid.Parse(accountId));
        }

        public void InsertCart(App.Support.Common.Models.Cart cart)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCart(string cartId)
        {
            throw new NotImplementedException();
        }
        
        public void UpdateCart(App.Support.Common.Models.Cart cart)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}