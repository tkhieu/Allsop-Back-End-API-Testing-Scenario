using System.Linq;
using System.Threading.Tasks;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.API.Catalog.Repositories;
using Service.API.Catalog.Repositories.Product;

namespace Service.API.Catalog.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductRepository _repository;

        public ProductsController(ProductRepository repository)
        {
            this._repository = repository;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ResultViewModel> Index()
        {
            return new ResultViewModel()
            {
                Data = this._repository.GetProducts(),
                Message = "Success",
                Status = Status.Success
            };
        }
    }
}