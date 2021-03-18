using System;
using System.Linq;
using System.Threading.Tasks;
using App.Support.Common.Configurations;
using App.Support.Common.gRPC.Clients;
using App.Support.Common.Models.CartService;
using App.Support.Common.Protos.Promotion;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.API.Cart.Repositories.Cart;
using Service.API.Cart.Repositories.CartItem;
using Service.API.Cart.Services.Cart;
using Service.API.Cart.ViewModels.Cart;

namespace Service.API.Cart.Controllers
{
    [Route("api/[controller]")]
    public class CartsController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartService _cartService;
        private readonly GrpcClientFactory _grpcClientFactory;

        public CartsController(CartRepository cartRepository, CartItemRepository cartItemRepository,
            CartService cartService, GrpcClientFactory grpcClientFactory)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
            _grpcClientFactory = grpcClientFactory;
        }

        // GET
        [HttpGet]
        [Route("Me")]
        [Authorize]
        public async Task<ResultViewModel> GetCart()
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId != null)
            {
                var cart = _cartRepository.GetCartByAccountId(accountId);

                if (cart == null)
                {
                    cart = _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));
                }

                var cartViewModel = await _cartService.GenerateCartViewModel(cart);

                return new ResultViewModel
                {
                    Data = cartViewModel,
                    Message = "Success",
                    Status = Status.Success
                };
            }

            return new ResultViewModel
            {
                Data = null,
                Message = "Error: You must login before add Cart Item into Cart",
                Status = Status.Error
            };
        }

        [HttpPost]
        [Route("Me")]
        [Authorize]
        public async Task<ResultViewModel> InsertToCart([FromBody] AdjustCartItemRequestViewModel model)
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId == null)
                return new ResultViewModel
                {
                    Data = null,
                    Message = "Error: You must login before add Cart Item into Cart",
                    Status = Status.Error
                };

            var cart = _cartRepository.GetCartByAccountId(accountId) ??
                       _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId.ToString() == model.ProductId);

            CartViewModel cartViewModel;
            if (model.Quantity <= 0)
            {
                cartViewModel = await _cartService.GenerateCartViewModel(cart);

                return new ResultViewModel
                {
                    Data = cartViewModel,
                    Message = "Error: You can not insert a Cart Item with negative quantity",
                    Status = Status.Error
                };
            }
            
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = Guid.Parse(model.ProductId),
                    Quantity = model.Quantity,
                    AddedAt = DateTime.Now,
                    CartId = cart.Id
                };
                await _cartRepository.InsertOrUpdateCart(cart);
                await _cartItemRepository.InsertCartItem(cartItem);
            }
            else
            {
                cartItem.Quantity = model.Quantity;
                await _cartItemRepository.UpdateCartItem(cartItem);
            }

            await _cartRepository.InsertOrUpdateCart(cart);
            
            cartViewModel = await _cartService.GenerateCartViewModel(cart);
            
            return new ResultViewModel
            {
                Data = cartViewModel,
                Message = "Success",
                Status = Status.Success
            };

        }
        
        [HttpPost]
        [Route("Me/DiscountCode")]
        [Authorize]
        public async Task<ResultViewModel> AddDiscountCodeToCart([FromBody] AddDiscountCodeRequestViewModel model)
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId == null)
                return new ResultViewModel
                {
                    Data = null,
                    Message = "Error: You must login before add Cart Item into Cart",
                    Status = Status.Error
                };

            var cart =  _cartRepository.GetCartByAccountId(accountId) ??
                       _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));


            await _cartService.RemoveDiscountCode(cart);
            var validateDiscountCodeDto =  await _cartService.AddDiscountCodeToCart(cart, model.DiscountCode);

            if (!validateDiscountCodeDto.IsValid)
            {
                return new ResultViewModel
                {
                    Data = validateDiscountCodeDto,
                    Message = "Add discount code error",
                    Status = Status.Error
                };
            }
            
            var cartViewModel = await _cartService.GenerateCartViewModel(cart);
            
            return new ResultViewModel
            {
                Data = cartViewModel,
                Message = "Success",
                Status = Status.Success
            };

        }

        [HttpPut]
        [Route("Me")]
        [Authorize]
        public async Task<ResultViewModel> AddToCart([FromBody] AdjustCartItemRequestViewModel model)
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId == null)
                return new ResultViewModel
                {
                    Data = null,
                    Message = "Error: You must login before add Cart Item into Cart",
                    Status = Status.Error
                };


            var cart = _cartRepository.GetCartByAccountId(accountId) ??
                       _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId.ToString() == model.ProductId);

            CartViewModel cartViewModel;
            if (cartItem == null && model.Quantity > 0)
            {
                cartItem = new CartItem
                {
                    ProductId = Guid.Parse(model.ProductId),
                    Quantity = model.Quantity,
                    AddedAt = DateTime.Now,
                    CartId = cart.Id
                };
                await _cartRepository.InsertOrUpdateCart(cart);
                await _cartItemRepository.InsertCartItem(cartItem);
            }
            else
            {
                cartViewModel = await _cartService.GenerateCartViewModel(cart);
                if (cartItem == null && model.Quantity < 0)
                {
                    return new ResultViewModel
                    {
                        Data = cartViewModel,
                        Message = "Error: You can not decrease a Cart Item quantity to negative",
                        Status = Status.Success
                    };
                }
                else
                {
                    if (cartItem != null)
                    {
                        cartItem.Quantity += model.Quantity;
                        if (cartItem.Quantity == 0)
                        {
                            await _cartItemRepository.DeleteCartItem(cartItem);
                        }
                        else
                        {
                            await _cartItemRepository.UpdateCartItem(cartItem);
                            await _cartRepository.InsertOrUpdateCart(cart);
                        }
                    }
                }
            }

            _cartRepository.RemoveEmptyCart(cart);
            
            cartViewModel = await _cartService.GenerateCartViewModel(cart);
            
            return new ResultViewModel
            {
                Data = cartViewModel,
                Message = "Success",
                Status = Status.Success
            };
        }

        [HttpDelete]
        [Route("Me")]
        [Authorize]
        public async Task<ResultViewModel> RemoveFromCart([FromBody] DeleteCartItemRequestViewModel model)
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId == null)
                return new ResultViewModel
                {
                    Data = null,
                    Message = "Error: You must login before add Cart Item into Cart",
                    Status = Status.Error
                };


            var cart = _cartRepository.GetCartByAccountId(accountId) ??
                       _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId.ToString() == model.ProductId);

            if (cartItem == null)
            {
                return new ResultViewModel
                {
                    Data = null,
                    Message = "Error: Cart Item does not exist inside Cart",
                    Status = Status.Error
                };
            }

            await _cartItemRepository.DeleteCartItem(cartItem);

            cart = _cartRepository.GetCartByAccountId(accountId);
            var cartViewModel = await _cartService.GenerateCartViewModel(cart);
            
            return new ResultViewModel
            {
                Data = cartViewModel,
                Message = "Success",
                Status = Status.Success
            };
        }
        
        [HttpDelete]
        [Route("Me/EmptyCart")]
        [Authorize]
        public async Task<ResultViewModel> EmptyCartFromCart()
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId == null)
                return new ResultViewModel
                {
                    Data = null,
                    Message = "Error: You must login before add Cart Item into Cart",
                    Status = Status.Error
                };


            var cart = _cartRepository.GetCartByAccountId(accountId) ??
                       _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));

            await _cartService.EmptyCart(cart);
            
           var newCart = _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));
            
            return new ResultViewModel
            {
                Data = newCart,
                Message = "Success",
                Status = Status.Success
            };
        }
    }
}