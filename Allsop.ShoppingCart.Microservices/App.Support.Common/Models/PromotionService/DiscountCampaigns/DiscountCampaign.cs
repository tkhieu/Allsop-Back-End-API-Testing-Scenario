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
        public string DiscountUnit { get; set; }
        public int DiscountValue { get; set; }
        public Guid? DiscountUnitId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        public string CampaignType { get; set; }
        public int Status { get; set; }
        public string ApplyOn { get; set; }
        public Guid? ApplyOnId { get; set; }
        public string CodePrefix { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public virtual ICollection<DiscountCode> DiscountCodes { get; set; }
        public virtual ICollection<Redemption> Redemptions { get; set; }
        public virtual ICollection<DiscountValidation> DiscountValidations { get; set; }
    }
}