using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Support.Common.gRPC.Clients;
using App.Support.Common.Models.CartService;
using App.Support.Common.Models.CatalogService;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;
using App.Support.Common.Protos.Cart;
using App.Support.Common.Protos.Catalog;
using App.Support.Common.Protos.Common;
using App.Support.Common.Protos.Promotion;
using Service.API.Cart.Repositories.Cart;
using Service.API.Cart.Repositories.CartItem;
using Service.API.Cart.ViewModels.Cart;

namespace Service.API.Cart.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly IGrpcClientFactory _grpcClientFactory;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public CartService(GrpcClientFactory grpcClientFactory, CartRepository cartRepository,
            CartItemRepository cartItemRepository)
        {
            _grpcClientFactory = grpcClientFactory;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
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

        public async Task<bool> CheckProductAvailability(Guid productId, long quantity)
        {
            var product = await GetProductFromProductId(productId);
            return product.InventoryQuantity >= quantity;
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

        public async Task<ProductDTO> GetProductDtoFromProductId(Guid productId)
        {
            var rq = new GetSingleProductRequest()
            {
                ProductId = productId.ToString()
            };
            var catalogGrpcClient = _grpcClientFactory.CreateCatalogGrpcClient();
            var response = await catalogGrpcClient.GetProductAsync(rq);
            var productDto = response.Product;

            return productDto;
        }

        public async Task<ValidateDiscountCodeDTO> ValidateDiscountCode(App.Support.Common.Models.CartService.Cart cart,
            string discountCode)
        {
            var promotionGrpcClient = _grpcClientFactory.CreatePromotionGrpcClient();
            var rq = new ValidateDiscountCodeWithCartRequest()
            {
                DiscountCode = discountCode,
                Cart = await GenerateCartDto(cart)
            };
            var response = await promotionGrpcClient.ValidateDiscountCodeAsync(rq);
            return response.ValidateDiscountCode;
        }

        public async Task<bool> RemoveDiscountCode(App.Support.Common.Models.CartService.Cart cart)
        {
            cart.DiscountCode = null;
            await _cartRepository.InsertOrUpdateCart(cart);
            return true;
        }

        public async Task<bool> EmptyCart(App.Support.Common.Models.CartService.Cart cart)
        {
            foreach (var cartItem in cart.CartItems)
            {
                await _cartItemRepository.DeleteCartItem(cartItem);
            }

            _cartRepository.DeleteCart(cart);

            return true;
        }

        private async Task<DiscountCampaignDTO> GetDiscountCampaignDetail(string discountCode)
        {
            var promotionGrpcClient = _grpcClientFactory.CreatePromotionGrpcClient();
            var discountCampaignDetailRequest = new GetDiscountCampaignDetailRequest()
            {
                DiscountCode = discountCode
            };
            var returnSingleDiscountCampaignResponse =
                await promotionGrpcClient.GetDiscountDetailAsync(discountCampaignDetailRequest);

            return returnSingleDiscountCampaignResponse.DiscountCampaign;
        }

        public async Task<CartViewModel> GenerateCartViewModel(App.Support.Common.Models.CartService.Cart cart)
        {
            var discountCategory = "";
            DiscountCampaign discountCampaign = null;
            DiscountCampaignDTO discountCampaignDto = null;

            if (cart.DiscountCode != null)
            {
                discountCampaignDto = await GetDiscountCampaignDetail(cart.DiscountCode);
                discountCampaign = DiscountCampaign.GenerateDiscountCampaignFromGrpcDto(discountCampaignDto);

                switch (discountCampaign.DiscountCampaignApplyOn)
                {
                    case DiscountCampaignApplyOn.Bill:
                    {
                        break;
                    }
                    case DiscountCampaignApplyOn.ProductCategory:
                    {
                        if (discountCampaign.ApplyOnId != null)
                        {
                            discountCategory = discountCampaign.ApplyOnId.Value.ToString();
                        }

                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var cartViewModel = new CartViewModel(cart);

            var subTotalAmount = 0m;
            var discountAmount = 0m;
            var totalAmount = 0m;

            foreach (var cartItemViewModel in cartViewModel.CartItems)
            {
                var productId = cartItemViewModel.ProductId;
                var product = await GetProductFromProductId(productId);
                cartItemViewModel.Product = product;

                cartItemViewModel.ItemSubTotalAmount = product.PriceValue * cartItemViewModel.Quantity;
                subTotalAmount += cartItemViewModel.ItemSubTotalAmount;

                if (cartItemViewModel.Product.Category.Id == discountCategory)
                {
                    if (discountCampaign != null)
                        switch (discountCampaign.DiscountCampaignType)
                        {
                            case DiscountCampaignType.Percentage:
                            {
                                if (discountCampaign.DiscountValue != null)
                                    cartItemViewModel.ItemDiscountAmount = cartItemViewModel.ItemSubTotalAmount *
                                        discountCampaign.DiscountValue.Value / 100;
                                break;
                            }
                        }
                }

                discountAmount += cartItemViewModel.ItemDiscountAmount;

                cartItemViewModel.ItemTotalAmount =
                    cartItemViewModel.ItemSubTotalAmount - cartItemViewModel.ItemDiscountAmount;
                totalAmount += cartItemViewModel.ItemTotalAmount;
            }

            if (discountCampaign != null)
            {
                switch (discountCampaign.DiscountCampaignType)
                {
                    case DiscountCampaignType.Money:
                    {
                        switch (discountCampaign.DiscountCampaignApplyOn)
                        {
                            case DiscountCampaignApplyOn.Bill:
                            {
                                if (discountCampaign.DiscountValue != null)
                                {
                                    discountAmount = discountCampaign.DiscountValue.Value;
                                    totalAmount -= discountAmount;
                                }
                            }
                                break;
                        }

                        break;
                    }
                }
            }


            cartViewModel.SubTotalAmount = subTotalAmount;
            cartViewModel.DiscountAmount = discountAmount;
            cartViewModel.TotalAmount = totalAmount;

            if (cart.DiscountCode == null) return cartViewModel;

            if (discountCampaign != null)
                cartViewModel.DiscountCampaignDto = discountCampaignDto;

            cartViewModel.AmountUnit = "GPB";

            return cartViewModel;
        }

        private async Task<CartDTO> GenerateCartDto(App.Support.Common.Models.CartService.Cart cart)
        {
            var subTotalAmount = 0m;
            var cartDto = new CartDTO
                {Id = cart.Id, AccountId = cart.AccountId.ToString(), CreatedAt = cart.CreatedAt.ToString()};

            if (cart.DiscountCode != null)
            {
                cartDto.DiscountCode = cart.DiscountCode;
            }

            foreach (var cartItem in cart.CartItems)
            {
                var cartItemDto = await GenerateCartItemDto(cartItem);
                subTotalAmount += cartItemDto.ItemSubTotalAmount.ToDecimal();
                cartDto.CartItems.Add(cartItemDto);
            }

            cartDto.SubTotalAmount = DecimalValue.FromDecimal(subTotalAmount);

            return cartDto;
        }

        private async Task<CartItemDTO> GenerateCartItemDto(CartItem cartItem)
        {
            var cartItemDto = new CartItemDTO
            {
                Id = cartItem.Id.ToString(),
                Quantity = (uint) cartItem.Quantity,
                AddedAt = cartItem.AddedAt.ToString(),
                ProductId = cartItem.ProductId.ToString()
            };

            var productDto = await GetProductDtoFromProductId(Guid.Parse(cartItemDto.ProductId));
            cartItemDto.Product = productDto;

            var itemSubTotalAmount = cartItemDto.Quantity * cartItemDto.Product.PriceValue.ToDecimal();
            cartItemDto.ItemSubTotalAmount = DecimalValue.FromDecimal(itemSubTotalAmount);

            return cartItemDto;
        }

        public async Task<ValidateDiscountCodeDTO> AddDiscountCodeToCart(
            App.Support.Common.Models.CartService.Cart cart, string discountCode)
        {
            var validateDiscountCodeDto = await ValidateDiscountCode(cart, discountCode);

            if (!validateDiscountCodeDto.IsValid) return validateDiscountCodeDto;

            cart.DiscountCode = discountCode;
            await _cartRepository.InsertOrUpdateCart(cart);

            return validateDiscountCodeDto;
        }
    }
}