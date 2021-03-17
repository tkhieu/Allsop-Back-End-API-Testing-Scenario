using System;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;

namespace App.Support.Common.Models.PromotionService.DiscountValidations
{
    public class DiscountValidation
    {
        public Guid Id { get; set; }
        public DiscountValidationOperator Operator { get; set; }
        public DiscountValidationValueType ValueType { get; set; }
        public string Value { get; set; }
        public Guid DiscountCampaignId { get; set; }
    }
}