using System.Threading.Tasks;
using App.Support.Common.ViewModels;
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
        public async Task<ResultViewModel> Index()
        {
            
            
            
            return new ResultViewModel()
            {
                Data = HttpContext.Items["UserId"],
                Message = "Message",
                Status = Status.Success
            };
        }
    }
}