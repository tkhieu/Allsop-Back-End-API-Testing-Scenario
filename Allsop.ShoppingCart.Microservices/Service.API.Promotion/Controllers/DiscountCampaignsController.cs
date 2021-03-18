using System;
using System.Threading.Tasks;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.API.Promotion.Repositories.DiscountCampaign;
using Service.API.Promotion.Services.DiscountCampaign;
using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Controllers
{
    [Route("api/[controller]")]
    public class DiscountCampaignsController : Controller
    {
        private IDiscountCampaignService _discountCampaignService;
        private IDiscountCampaignRepository _discountCampaignRepository;

        public DiscountCampaignsController(DiscountCampaignService discountCampaignService, DiscountCampaignRepository discountCampaignRepository)
        {
            this._discountCampaignService = discountCampaignService;
            this._discountCampaignRepository = discountCampaignRepository;
        }
        
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

            var discountCampaign = _discountCampaignService.GenerateDiscountCampaignFromViewModel(model);
            await _discountCampaignRepository.Insert(discountCampaign);
            
            return new ResultViewModel()
            {
                Status = Status.Success,
                Message = "Testing",
                Data = discountCampaign
            };
        }
    }
}