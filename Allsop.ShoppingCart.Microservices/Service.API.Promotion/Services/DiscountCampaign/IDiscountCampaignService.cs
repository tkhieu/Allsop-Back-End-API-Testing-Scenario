using System.Threading.Tasks;
using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Services.DiscountCampaign
{
    public interface IDiscountCampaignService
    {
        App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign
            GenerateDiscountCampaignFromViewModel(DiscountCampaignRequestViewModel viewModel);

        Task<bool> CheckDuplicateCampaign(DiscountCampaignRequestViewModel discountCampaign);
    }
}