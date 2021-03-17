using System.Threading.Tasks;
using Service.API.Promotion.Infrastructure;

namespace Service.API.Promotion.Repositories.DiscountCampaign
{
    public class DiscountCampaignRepository: IDiscountCampaignRepository
    {

        private PromotionDbContext _promotionDbContext;

        public DiscountCampaignRepository(PromotionDbContext promotionDbContext)
        {
            this._promotionDbContext = promotionDbContext;
        }
        
        public async Task<App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign> Insert(App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign discountCampaign)
        {
            this._promotionDbContext.DiscountCampaigns.Add(discountCampaign);
            await this._promotionDbContext.SaveChangesAsync();
            return discountCampaign;
        }
    }
}