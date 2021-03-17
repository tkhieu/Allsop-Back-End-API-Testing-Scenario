using System;
using App.Support.Common.Models;
using Service.API.Cart.ViewModels.Cart;

namespace Service.API.Cart.Services.Cart
{
    public interface ICartService
    {
        App.Support.Common.Models.Cart GenerateAnEmptyCart(Guid accountId);
        CartViewModel GenerateCartViewModel(App.Support.Common.Models.Cart cart);
    }
}