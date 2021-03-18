using System;
using System.Collections.Generic;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;
using App.Support.Common.Models.PromotionService.Redemptions;

namespace App.Support.Common.Models.PromotionService.DiscountCodes
{
    public class DiscountCode
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string NormalizedCode { get; set; }
        public DiscountCodeStatus Status { get; set; }
        public Guid DiscountCampaignId { get; set; }
        
        public int MaxRedeem { get; set; }

        public virtual ICollection<Redemption> Redemptions { get; set; }
    }
}