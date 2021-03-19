using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.API.Promotion.Infrastructure;

namespace Service.API.Promotion.Repositories.DiscountCampaign
{
    public class DiscountCampaignRepository: IDiscountCampaignRepository
    {

        private readonly PromotionDbContext _promotionDbContext;

        public DiscountCampaignRepository(PromotionDbContext promotionDbContext)
        {
            _promotionDbContext = promotionDbContext;
        }
        
        public async Task<App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign> Insert(App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign discountCampaign)
        {
            _promotionDbContext.DiscountCampaigns.Add(discountCampaign);
            await _promotionDbContext.SaveChangesAsync();
            return discountCampaign;
        }

        public async Task<App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign> GetById(Guid discountCampaignId)
        {
            return await _promotionDbContext.DiscountCampaigns.Include("DiscountValidations")
                .FirstOrDefaultAsync(d => d.Id == discountCampaignId);
            
        }

        public async Task<ICollection<App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign>> GetAll()
        {
            return await _promotionDbContext.DiscountCampaigns.ToListAsync();
        }
    }
}