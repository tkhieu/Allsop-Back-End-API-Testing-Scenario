using System;
using System.Threading.Tasks;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.API.Cart.Repositories.Cart;
using Service.API.Cart.Services.Cart;

namespace Service.API.Cart.Controllers
{
    [Route("api/[controller]")]
    public class CartsController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartService _cartService;
        
        public CartsController(CartRepository cartRepository, CartService cartService)
        {
            this._cartRepository = cartRepository;
            this._cartService = cartService;
        }
        
        // GET
        
        [HttpGet]
        [Route("Me")]
        [Authorize]
        public async Task<ResultViewModel> GetCart()
        {
            var userId = HttpContext.Items["UserId"]?.ToString();

            if (userId != null)
            {
                var cart = _cartRepository.GetCartByAccountId(userId);

                if (cart == null)
                {
                    cart = _cartService.GenerateAnEmptyCart(Guid.Parse(userId));
                }
            
                return new ResultViewModel()
                {
                    Data = cart,
                    Message = "Message",
                    Status = Status.Success
                };
            }
            
            return new ResultViewModel()
            {
                Data = null,
                Message = "Message",
                Status = Status.Error
            };
        } 
    }
}