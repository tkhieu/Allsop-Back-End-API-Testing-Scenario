using System;
using System.Collections.Generic;
using App.Support.Common.Models.PromotionService.DiscountCodes;
using App.Support.Common.Models.PromotionService.DiscountValidations;
using App.Support.Common.Models.PromotionService.Redemptions;

namespace App.Support.Common.Models.PromotionService.DiscountCampaigns
{
    public class DiscountCampaign
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? DiscountValue { get; set; }
        public Guid? DiscountUnitId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        public DiscountCampaignType DiscountCampaignType { get; set; }
        
        public DiscountCampaignApplyOn DiscountCampaignApplyOn { get; set; }
        
        public Guid? ApplyOnId { get; set; }
        
        public string CodePrefix { get; set; }
        
        public virtual ICollection<DiscountCode> DiscountCodes { get; set; }
        public virtual ICollection<Redemption> Redemptions { get; set; }
        public virtual ICollection<DiscountValidation> DiscountValidations { get; set; }
    }
}