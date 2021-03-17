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

            DiscountCampaign discountCampaign = new DiscountCampaign();

            switch (model.CodeType)
            {
                case CodeType.SingleCode:
                {
                    var code = model.SingleCode;
                    
                
                    Console.WriteLine(model.CodeType);
                    Console.WriteLine(code);
                    break;
                }
                case CodeType.BulkCodes:
                {
                    var codeAmount = model.CodesAmount;
                
                    Console.WriteLine(model.CodeType);
                    Console.WriteLine(codeAmount);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (model.DiscountCampaignType)
            {
                case DiscountCampaignType.Money:
                {
                    if (model.DiscountValue != null)
                    {
                        var discountValue = model.DiscountValue.Value;
                        Console.WriteLine(model.DiscountCampaignType);
                        Console.WriteLine(discountValue);
                    }
                    break;
                }

                case DiscountCampaignType.Percentage:
                {
                    if (model.DiscountValue != null)
                    {
                        var discountValue = model.DiscountValue.Value;
                        Console.WriteLine(model.DiscountCampaignType);
                        Console.WriteLine(discountValue);
                    }

                    break;
                }

                case DiscountCampaignType.Product:
                {
                    if (model.DiscountUnitId != null)
                    {
                        var discountUnitId = model.DiscountUnitId;
                        Console.WriteLine(model.DiscountCampaignType);
                        Console.WriteLine(discountUnitId);
                    }
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (model.DiscountCampaignApplyOn)
            {
                case DiscountCampaignApplyOn.Bill:
                {
                    break;
                }
                case DiscountCampaignApplyOn.Product:
                {
                    break;
                }
                case DiscountCampaignApplyOn.ProductCategory:
                {
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
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