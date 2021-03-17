using System;
using System.Threading.Tasks;
using App.Support.Common.Models;
using App.Support.Common.Models.CatalogService;
using App.Support.Common.Protos.Promotion;
using Service.API.Cart.ViewModels.Cart;

namespace Service.API.Cart.Services.Cart
{
    public interface ICartService
    {
        App.Support.Common.Models.CartService.Cart GenerateAnEmptyCart(Guid accountId);
        Task<CartViewModel> GenerateCartViewModel(App.Support.Common.Models.CartService.Cart cart);
        Task<ValidateDiscountCodeDTO> AddDiscountCodeToCart(App.Support.Common.Models.CartService.Cart cart, string discountCode);
        Task<Product> GetProductFromProductId(Guid productId);
        Task<ValidateDiscountCodeDTO> ValidateDiscountCode(App.Support.Common.Models.CartService.Cart cart,
            string discountCode);
        Task<bool> RemoveDiscountCode(App.Support.Common.Models.CartService.Cart cart);
    }
}