using System;
using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Services.DiscountCampaign
{
    public class DiscountCampaignService: IDiscountCampaignService
    {
        public App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign generateDiscountCampaignFromViewModel(DiscountCampaignRequestViewModel viewModel)
        {
            App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign discountCampaign =
                new App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign();
            
            discountCampaign.Id = Guid.NewGuid();
            discountCampaign.Name = viewModel.Name;
            discountCampaign.DiscountCampaignType = viewModel.DiscountCampaignType;
            discountCampaign.DiscountValue = viewModel.DiscountValue;
            discountCampaign.DiscountUnitId = viewModel.DiscountUnitId;
            discountCampaign.StartDate = viewModel.StartDate;
            discountCampaign.ExpirationDate = viewModel.ExpirationDate;
            discountCampaign.DiscountCampaignApplyOn = viewModel.DiscountCampaignApplyOn;
            discountCampaign.ApplyOnId = viewModel.DiscountCampaignApplyOnId;
            discountCampaign.CodePrefix = viewModel.CodePrefix;

            return discountCampaign;
            
            //
            // switch (model.CodeType)
            // {
            //     case CodeType.SingleCode:
            //     {
            //         var code = model.SingleCode;
            //         
            //     
            //         Console.WriteLine(model.CodeType);
            //         Console.WriteLine(code);
            //         break;
            //     }
            //     case CodeType.BulkCodes:
            //     {
            //         var codeAmount = model.CodesAmount;
            //     
            //         Console.WriteLine(model.CodeType);
            //         Console.WriteLine(codeAmount);
            //         break;
            //     }
            //     default:
            //         throw new ArgumentOutOfRangeException();
            // }
            //
            // switch (model.DiscountCampaignType)
            // {
            //     case DiscountCampaignType.Money:
            //     {
            //         if (model.DiscountValue != null)
            //         {
            //             var discountValue = model.DiscountValue.Value;
            //             Console.WriteLine(model.DiscountCampaignType);
            //             Console.WriteLine(discountValue);
            //         }
            //         break;
            //     }
            //
            //     case DiscountCampaignType.Percentage:
            //     {
            //         if (model.DiscountValue != null)
            //         {
            //             var discountValue = model.DiscountValue.Value;
            //             Console.WriteLine(model.DiscountCampaignType);
            //             Console.WriteLine(discountValue);
            //         }
            //
            //         break;
            //     }
            //
            //     case DiscountCampaignType.Product:
            //     {
            //         if (model.DiscountUnitId != null)
            //         {
            //             var discountUnitId = model.DiscountUnitId;
            //             Console.WriteLine(model.DiscountCampaignType);
            //             Console.WriteLine(discountUnitId);
            //         }
            //         break;
            //     }
            //     default:
            //         throw new ArgumentOutOfRangeException();
            // }
            //
            // switch (model.DiscountCampaignApplyOn)
            // {
            //     case DiscountCampaignApplyOn.Bill:
            //     {
            //         break;
            //     }
            //     case DiscountCampaignApplyOn.Product:
            //     {
            //         break;
            //     }
            //     case DiscountCampaignApplyOn.ProductCategory:
            //     {
            //         break;
            //     }
            //     default:
            //         throw new ArgumentOutOfRangeException();
            // }
        }
    }
}