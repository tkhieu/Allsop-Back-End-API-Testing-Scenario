using System;
using System.Linq;
using System.Threading.Tasks;
using App.Support.Common.Configurations;
using App.Support.Common.Models;
using App.Support.Common.Protos.Catalog;
using App.Support.Common.ViewModels;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.API.Cart.Repositories.Cart;
using Service.API.Cart.Repositories.CartItem;
using Service.API.Cart.Services.Cart;
using Service.API.Cart.ViewModels.Cart;
using Status = App.Support.Common.ViewModels.Status;

namespace Service.API.Cart.Controllers
{
    [Route("api/[controller]")]
    public class CartsController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartService _cartService;

        public CartsController(CartRepository cartRepository, CartItemRepository cartItemRepository,
            CartService cartService)
        {
            this._cartRepository = cartRepository;
            this._cartItemRepository = cartItemRepository;
            this._cartService = cartService;
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

                return new ResultViewModel()
                {
                    Data = cart,
                    Message = "Success",
                    Status = Status.Success
                };
            }

            return new ResultViewModel()
            {
                Data = null,
                Message = "Error: You must login before add Cart Item into Cart",
                Status = Status.Error
            };
        }

        [HttpPost]
        [Route("Me")]
        [Authorize]
        public async Task<ResultViewModel> InsertToCart([FromBody] AdjustCartItemViewModel model)
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId == null)
                return new ResultViewModel()
                {
                    Data = null,
                    Message = "Error: You must login before add Cart Item into Cart",
                    Status = Status.Error
                };

            var cart = _cartRepository.GetCartByAccountId(accountId) ??
                       _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == model.ProductId);

            if (model.Quantity <= 0)
                return new ResultViewModel()
                {
                    Data = cart,
                    Message = "Error: You can not insert a Cart Item with negative quantity",
                    Status = Status.Error
                };
            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    AddedAt = DateTime.Now,
                    CartId = cart.Id
                };
                await _cartItemRepository.InsertCartItem(cartItem);
            }
            else
            {
                cartItem.Quantity = model.Quantity;
                await _cartItemRepository.UpdateCartItem(cartItem);
            }

            await _cartRepository.InsertCart(cart);
            return new ResultViewModel()
            {
                Data = cart,
                Message = "Success",
                Status = Status.Success
            };

        }

        [HttpPut]
        [Route("Me")]
        [Authorize]
        public async Task<ResultViewModel> AddToCart([FromBody] AdjustCartItemViewModel model)
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId == null)
                return new ResultViewModel()
                {
                    Data = null,
                    Message = "Error: You must login before add Cart Item into Cart",
                    Status = Status.Error
                };


            var cart = _cartRepository.GetCartByAccountId(accountId) ??
                       _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == model.ProductId);

            if (cartItem == null && model.Quantity > 0)
            {
                cartItem = new CartItem()
                {
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    AddedAt = DateTime.Now,
                    CartId = cart.Id
                };
                await _cartRepository.UpdateCart(cart);
                await _cartItemRepository.InsertCartItem(cartItem);
            }
            else if (cartItem == null && model.Quantity < 0)
            {
                return new ResultViewModel()
                {
                    Data = cart,
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
                        _cartItemRepository.DeleteCartItem(cartItem);
                    }
                    else
                    {
                        await _cartRepository.UpdateCart(cart);
                        await _cartItemRepository.UpdateCartItem(cartItem);
                    }
                }
            }
            
            _cartRepository.RemoveEmptyCart(cart);
            return new ResultViewModel()
            {
                Data = cart,
                Message = "Success",
                Status = Status.Success
            };
        }

        [HttpDelete]
        [Route("Me")]
        [Authorize]
        public async Task<ResultViewModel> RemoveFromCart([FromBody] DeleteCartItemViewModel model)
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId == null)
                return new ResultViewModel()
                {
                    Data = null,
                    Message = "Error: You must login before add Cart Item into Cart",
                    Status = Status.Error
                };


            var cart = _cartRepository.GetCartByAccountId(accountId) ??
                       _cartService.GenerateAnEmptyCart(Guid.Parse(accountId));

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == model.ProductId);

            if (cartItem == null)
            {
                return new ResultViewModel()
                {
                    Data = null,
                    Message = "Error: Cart Item does not exist inside Cart",
                    Status = Status.Error
                };
            }
            else
            {
                _cartItemRepository.DeleteCartItem(cartItem);
            }

            return new ResultViewModel()
            {
                Data = cart,
                Message = "Success",
                Status = Status.Success
            };
        }
        
        
        [HttpPost]
        [Route("TestGrpc")]
        [Authorize]
        public async Task<ResultViewModel> TestGrpc([FromBody] AdjustCartItemViewModel model)
        {
            var accountId = HttpContext.Items[AppConsts.HttpContextItemAccountId]?.ToString();

            if (accountId == null)
                return new ResultViewModel()
                {
                    Data = null,
                    Message = "Error: You must login before add Cart Item into Cart",
                    Status = Status.Error
                };

            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var client = new ProductGrpc.ProductGrpcClient(channel);
            var reply = await client.GetProductAsync(new GetSingleProductRequest()
            {
                Id = model.ProductId
            });
            
            return new ResultViewModel()
            {
                Data = reply,
                Message = "Success",
                Status = Status.Success
            };
        }
    }
}