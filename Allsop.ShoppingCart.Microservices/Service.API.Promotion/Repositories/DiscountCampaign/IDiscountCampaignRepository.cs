using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.API.Promotion.Repositories.DiscountCampaign
{
    public interface IDiscountCampaignRepository
    {

        Task<App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign> Insert(
            App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign discountCampaign);
        
        Task<App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign> GetById(
            Guid discountCampaignId);
        
        Task<ICollection<App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign>> GetAll();

        Task<App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign> GetByCodePrefix(string codePrefix);
    }
}