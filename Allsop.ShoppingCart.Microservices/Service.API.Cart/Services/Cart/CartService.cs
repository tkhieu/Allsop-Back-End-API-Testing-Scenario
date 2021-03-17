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
        private readonly IGrpcClientFactory _grpcClientFactory;
        private readonly ICartRepository _cartRepository;

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

        public async Task<Product> GetProductFromProductId(Guid productId)
        {
            var rq = new GetSingleProductRequest()
            {
                ProductId = productId.ToString()
            };
            var catalogGrpcClient = _grpcClientFactory.CreateCatalogGrpcClient();
            var response = await catalogGrpcClient.GetProductAsync(rq);
            var productDto = response.Product;
            var product = Product.GenerateProductFromGrpcDto(productDto);

            return product;
        }

        public async Task<bool> ValidateDiscountCode(App.Support.Common.Models.CartService.Cart cart,
            string discountCode)
        {
            var promotionGrpcClient = _grpcClientFactory.CreatePromotionGrpcClient();
            var rq = new ValidateDiscountCodeWithCartRequest()
            {
                DiscountCode = discountCode,
                Cart = cart.GenerateCartDto()
            };
            var response = await promotionGrpcClient.ValidateDiscountCodeAsync(rq);

            return response.Status == GrpcStatus.Success && response.ValidateDiscountCode.IsValid;
        }

        public async Task<CartViewModel> GenerateCartViewModel(App.Support.Common.Models.CartService.Cart cart)
        {
            var cartViewModel = new CartViewModel(cart);
            
            foreach (var cartItemViewModel in cartViewModel.CartItems)
            {
                var productId = cartItemViewModel.ProductId;
                var product = await GetProductFromProductId(productId);
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
            var codeValid = await ValidateDiscountCode(cart, discountCode);
            
            if (!codeValid) return false;
            
            cart.DiscountCode = discountCode;
            await _cartRepository.InsertOrUpdateCart(cart);

            return true;



        }
    }
}