using System.Threading.Tasks;

namespace Service.API.Promotion.Repositories.DiscountCampaign
{
    public interface IDiscountCampaignRepository
    {

        Task<App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign> Insert(
            App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign discountCampaign);

    }
}