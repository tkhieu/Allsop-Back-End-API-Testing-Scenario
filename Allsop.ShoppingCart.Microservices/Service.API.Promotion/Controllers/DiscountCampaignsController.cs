using System;
using System.Threading.Tasks;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Controllers
{
    [Route("api/[controller]")]
    public class DiscountCampaignsController : Controller
    {
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ResultViewModel> Post([FromBody] DiscountCampaignRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultViewModel()
                {
                    Status = Status.Error,
                    Message = "Invalid Data",
                    Data = {}
                };
            }

            if (model.CodeType.Equals(CodeType.SingleCode))
            {
                var code = model.SingleCode;
                
                Console.WriteLine(model.CodeType);
                Console.WriteLine(code);
            }
            else if (model.CodeType.Equals(CodeType.BulkCodes))
            {
                int codeAmount = model.CodesAmount;
                
                Console.WriteLine(model.CodeType);
                Console.WriteLine(codeAmount);
            }
            
            return new ResultViewModel()
            {
                Status = Status.Success,
                Message = "Testing",
                Data = {}
            };
        }
    }
}