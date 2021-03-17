using System;
using System.Collections.Generic;
using System.ComponentModel;
using App.Support.Common.gRPC.Clients;
using App.Support.Common.Models;
using App.Support.Common.Models.CartService;
using App.Support.Common.Models.CatalogService;
using App.Support.Common.Protos.Catalog;
using Service.API.Cart.ViewModels.Cart;

namespace Service.API.Cart.Services.Cart
{
    public class CartService: ICartService
    {
        private IGrpcClientFactory _grpcClientFactory;

        public CartService(GrpcClientFactory grpcClientFactory)
        {
            this._grpcClientFactory = grpcClientFactory;
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

        public CartViewModel GenerateCartViewModel(App.Support.Common.Models.CartService.Cart cart)
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
                var response = catalogGrpcClient.GetProduct(rq);
                var productDto = response.Product;
                var product = Product.GenerateProductFromGrpcDto(productDto);
                cartItemViewModel.Product = product;
            }

            return cartViewModel;
        }
    }
}