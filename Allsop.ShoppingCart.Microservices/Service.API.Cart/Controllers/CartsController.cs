using System.Threading.Tasks;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.API.Cart.Repositories.Cart;

namespace Service.API.Cart.Controllers
{
    [Route("api/[controller]")]
    public class CartsController : Controller
    {
        private readonly ICartRepository _cartRepository;
        
        public CartsController(CartRepository cartRepository)
        {
            this._cartRepository = cartRepository;
        }
        
        // GET
        
        [HttpGet]
        [Route("Me")]
        [Authorize]
        public async Task<ResultViewModel> GetCart()
        {
            var userId = HttpContext.Items["UserId"]?.ToString();

            var cart = _cartRepository.GetCartByAccountId(userId);

            if (cart == null)
            {
                cart = new App.Support.Common.Models.Cart();
            }
            
            return new ResultViewModel()
            {
                Data = cart,
                Message = "Message",
                Status = Status.Success
            };
        }
    }
}