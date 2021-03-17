using System;
using System.Threading.Tasks;
using App.Support.Common.Models;
using Service.API.Cart.ViewModels.Cart;

namespace Service.API.Cart.Services.Cart
{
    public interface ICartService
    {
        App.Support.Common.Models.CartService.Cart GenerateAnEmptyCart(Guid accountId);
        Task<CartViewModel> GenerateCartViewModel(App.Support.Common.Models.CartService.Cart cart);
        Task<bool> AddDiscountCodeToCart(App.Support.Common.Models.CartService.Cart cart, string discountCode);
    }
}