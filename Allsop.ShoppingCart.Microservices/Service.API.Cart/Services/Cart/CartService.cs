using System;
using App.Support.Common.Models;

namespace Service.API.Cart.Services.Cart
{
    public class CartService: ICartService
    {
        public App.Support.Common.Models.Cart GenerateAnEmptyCart(Guid accountId)
        {
            var cart = new App.Support.Common.Models.Cart()
            {
                AccountId = accountId,
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid().ToString()
            };

            return cart;
        }
    }
}