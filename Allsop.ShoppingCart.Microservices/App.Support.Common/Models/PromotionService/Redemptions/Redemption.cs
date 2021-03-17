using System;
using App.Support.Common.Models.IdentityService;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;
using App.Support.Common.Models.PromotionService.DiscountCodes;

namespace App.Support.Common.Models.PromotionService.Redemptions
{
    public class Redemption
    {
        public Guid Id { get; set; }
        public DateTimeOffset RedeemTime { get; set; }
        public decimal? Amount { get; set; }
        public Guid DiscountCodeId { get; set; }
        public virtual DiscountCode DiscountCode { get; set; }
        public Guid DiscountCampaignId { get; set; }
        public virtual DiscountCampaign DiscountCampaign { get; set; }
        public string AccountId { get; set; }
        public virtual Account Account { get; set; }
        public Guid OrderId { get; set; }
    }
}