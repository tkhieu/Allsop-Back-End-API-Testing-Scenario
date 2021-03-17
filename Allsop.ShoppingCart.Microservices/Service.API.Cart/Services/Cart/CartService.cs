using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using App.Support.Common.gRPC.Clients;
using App.Support.Common.Models;
using App.Support.Common.Models.CartService;
using App.Support.Common.Models.CatalogService;
using App.Support.Common.Protos.Catalog;
using App.Support.Common.Protos.Common;
using App.Support.Common.Protos.Promotion;
using Service.API.Cart.Repositories.Cart;
using Service.API.Cart.ViewModels.Cart;

namespace Service.API.Cart.Services.Cart
{
    public class CartService: ICartService
    {
        private IGrpcClientFactory _grpcClientFactory;
        private ICartRepository _cartRepository;

        public CartService(GrpcClientFactory grpcClientFactory, CartRepository cartRepository)
        {
            _grpcClientFactory = grpcClientFactory;
            _cartRepository = cartRepository;
        }
        
        public App.Support.Common.Models.CartService.Cart GenerateAnEmptyCart(Guid accountId)
        {
            var cart = new App.Support.Common.Models.CartService.Cart()
            {
                AccountId = accountId,
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                CartItems = new List<CartItem>()
            };

            return cart;
        }

        public async Task<CartViewModel> GenerateCartViewModel(App.Support.Common.Models.CartService.Cart cart)
        {
            var cartViewModel = new CartViewModel(cart);

            var catalogGrpcClient = _grpcClientFactory.CreateCatalogGrpcClient();
            
            foreach (var cartItemViewModel in cartViewModel.CartItems)
            {
                var productId = cartItemViewModel.ProductId;
                var rq = new GetSingleProductRequest()
                {
                    ProductId = productId.ToString()
                };
                var response = await catalogGrpcClient.GetProductAsync(rq);
                var productDto = response.Product;
                var product = Product.GenerateProductFromGrpcDto(productDto);
                cartItemViewModel.Product = product;
            }
            
            var promotionGrpcClient = _grpcClientFactory.CreatePromotionGrpcClient();
            var discountCampaignDetailRequest = new GetDiscountCampaignDetailRequest()
            {
                DiscountCode = cart.DiscountCode
            };
            var returnSingleDiscountCampaignResponse = await promotionGrpcClient.GetDiscountDetailAsync(discountCampaignDetailRequest);
            
            cartViewModel.DiscountCampaignDto = returnSingleDiscountCampaignResponse.DiscountCampaign;

            return cartViewModel;
        }

        public async Task<bool> AddDiscountCodeToCart(App.Support.Common.Models.CartService.Cart cart, string discountCode)
        {
            //TODO: Convert to discount code validation
            var promotionGrpcClient = _grpcClientFactory.CreatePromotionGrpcClient();
            var rq = new GetDiscountCampaignDetailRequest()
            {
                DiscountCode = discountCode
            };
            var response = await promotionGrpcClient.GetDiscountDetailAsync(rq);

            if (response.Status != GrpcStatus.Success) return false;
            
            cart.DiscountCode = discountCode;
            await _cartRepository.InsertOrUpdateCart(cart);
            return true;
        }
    }
}