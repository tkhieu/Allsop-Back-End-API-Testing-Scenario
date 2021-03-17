using System;
using System.Collections.Generic;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;

namespace Service.API.Promotion.ViewModels
{
    public class DiscountCampaignRequestViewModel
    {
        public string Name { get; set; }
        public int CodesAmount { get; set; }
        public string SingleCode { get; set; }
        public CodeType CodeType { get; set; }
        public DiscountCampaignType DiscountCampaignType { get; set; }
        public decimal? DiscountValue { get; set; }
        public Guid? DiscountUnitId { get; set; }
        
        public DateTimeOffset? StartDate { get; set; }
        
        public DateTimeOffset? ExpirationDate { get; set; }
        
        public DiscountCampaignApplyOn DiscountCampaignApplyOn { get; set; }
        public Guid? DiscountCampaignApplyOnId { get; set; }
        
        public string CodePrefix { get; set; }
        
        public int MaxRedeem { get; set; }
        
        public List<DiscountValidationRequestViewModel> DiscountValidations { get; set; }
    }
}

