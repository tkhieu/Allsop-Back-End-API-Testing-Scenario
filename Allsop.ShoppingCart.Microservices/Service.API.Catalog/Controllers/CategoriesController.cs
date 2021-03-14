using System.Threading.Tasks;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.API.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoriesController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<ResultViewModel> Index()
        {
            return new ResultViewModel();
        }
    }
}