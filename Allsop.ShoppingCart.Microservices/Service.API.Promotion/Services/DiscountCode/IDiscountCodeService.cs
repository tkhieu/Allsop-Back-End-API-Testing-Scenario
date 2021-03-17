using System.Collections.Generic;
using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Services.DiscountCode
{
    public interface IDiscountCodeService
    {
        ICollection<App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode> GenerateDiscountCodesFromDiscountCampaignViewModel(
            DiscountCampaignRequestViewModel viewModel);
    }
}