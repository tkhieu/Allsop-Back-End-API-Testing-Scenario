using App.Support.Common.Models.CatalogService;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;
using App.Support.Common.Models.PromotionService.DiscountCodes;
using App.Support.Common.Models.PromotionService.Redemptions;
using Microsoft.EntityFrameworkCore;

namespace Service.API.Promotion.Infrastructure
{
    public class PromotionDbContext : DbContext
    {
        public PromotionDbContext(DbContextOptions<PromotionDbContext> options)
            : base(options)
        {
        }

        public DbSet<DiscountCampaign> DiscountCampaigns { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<Redemption> Redemptions { get; set; }
        
    }
}