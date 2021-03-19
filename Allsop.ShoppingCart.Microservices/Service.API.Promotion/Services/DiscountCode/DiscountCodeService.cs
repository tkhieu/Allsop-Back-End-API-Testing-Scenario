using System;
using System.Collections.Generic;
using App.Support.Common;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;
using App.Support.Common.Models.PromotionService.DiscountCodes;
using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Services.DiscountCode
{
    public class DiscountCodeService: IDiscountCodeService
    {
        public ICollection<App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode> GenerateDiscountCodesFromDiscountCampaignViewModel(DiscountCampaignRequestViewModel viewModel)
        {
            ICollection<App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode> discountCodes =
                new List<App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode>();
            
            switch (viewModel.CodeType)
            {
                case CodeType.SingleCode:
                {
                    var discountCode = new App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode
                    {
                        Id = Guid.NewGuid(),
                        Code = viewModel.SingleCode,
                        NormalizedCode = viewModel.SingleCode.Normalize(),
                        Status = DiscountCodeStatus.Active,
                        MaxRedeem = viewModel.MaxRedeem
                    };


                    discountCodes.Add(discountCode);
                    
                    break;
                }
                case CodeType.BulkCodes:
                {
                    var count = viewModel.CodesAmount;

                    for (var i = 0; i < count; i++)
                    {
                        var discountCode = new App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode
                        {
                            Id = Guid.NewGuid(),
                            Code = $"{viewModel.CodePrefix}-{DiscountCodeHelper.RandomString(5)}",
                            Status = DiscountCodeStatus.Active,
                            MaxRedeem = 1
                        };

                        discountCode.NormalizedCode = DiscountCodeHelper.ReplaceDash(discountCode.Code).Normalize();
                        
                        discountCodes.Add(discountCode);
                    }
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return discountCodes;
        }
    }
}