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
        public int Status { get; set; }
        public Guid DiscountCampaignId { get; set; }
        public virtual DiscountCampaign DiscountCampaign { get; set; }

        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public virtual ICollection<Redemption> Redemptions { get; set; }
    }
}