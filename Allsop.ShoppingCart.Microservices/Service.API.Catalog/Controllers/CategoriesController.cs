using System.Linq;
using System.Threading.Tasks;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.API.Catalog.Repositories;

namespace Service.API.Catalog.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;

        public CategoriesController(CategoryRepository categoryRepository, ProductRepository productRepository)
        {
            this._categoryRepository = categoryRepository;
            this._productRepository = productRepository;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ResultViewModel> Index()
        {
            return new ResultViewModel()
            {
                Data = this._categoryRepository.GetCategories().ToList(),
                Message = "Success",
                Status = Status.Success
            };
        }
        
        [HttpGet("{categoryId:Guid}")]
        [Authorize]
        public async Task<ResultViewModel> GetProductsByCategoryId(string categoryId)
        {
            return new ResultViewModel()
            {
                Data = this._productRepository.GetProductsByCategoryId(categoryId),
                Message = "Success",
                Status = Status.Success
            };
        }
    }
}