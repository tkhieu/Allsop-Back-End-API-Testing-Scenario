using System;
using System.Collections.Generic;
using System.Linq;
using Service.API.Promotion.Services.DiscountValidation;
using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Services.DiscountCampaign
{
    public class DiscountCampaignService: IDiscountCampaignService
    {
        private IDiscountValidationService _discountValidationService;

        public DiscountCampaignService(DiscountValidationService discountValidationService)
        {
            this._discountValidationService = discountValidationService;
        }
        
        public App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign GenerateDiscountCampaignFromViewModel(DiscountCampaignRequestViewModel viewModel)
        {
            var discountCampaign =
                new App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign
                {
                    Id = Guid.NewGuid(),
                    Name = viewModel.Name,
                    DiscountCampaignType = viewModel.DiscountCampaignType,
                    DiscountValue = viewModel.DiscountValue,
                    DiscountUnitId = viewModel.DiscountUnitId,
                    StartDate = viewModel.StartDate,
                    ExpirationDate = viewModel.ExpirationDate,
                    DiscountCampaignApplyOn = viewModel.DiscountCampaignApplyOn,
                    ApplyOnId = viewModel.DiscountCampaignApplyOnId,
                    CodePrefix = viewModel.CodePrefix
                };

            discountCampaign.DiscountValidations =
                new List<App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation>();
            foreach (var discountValidation in viewModel.DiscountValidations.Select(viewModelDiscountValidation => _discountValidationService.GenerateDiscountValidationFromViewModel(viewModelDiscountValidation)))
            {
                discountCampaign.DiscountValidations.Add(discountValidation);
            }




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