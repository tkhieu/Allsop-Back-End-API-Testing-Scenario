using System;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;

namespace App.Support.Common.Models.PromotionService.DiscountValidations
{
    public class DiscountValidation
    {
        public Guid Id { get; set; }
        public string Rule { get; set; }
        public string Operator { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
        public Guid DiscountCampaignId { get; set; }
        public virtual DiscountCampaign DiscountCampaign { get; set; }

        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}