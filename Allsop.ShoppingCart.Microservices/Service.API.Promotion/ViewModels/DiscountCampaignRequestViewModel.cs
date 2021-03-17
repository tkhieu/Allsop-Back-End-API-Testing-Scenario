using System;
using System.Collections.Generic;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;

namespace Service.API.Promotion.ViewModels
{
    public class DiscountCampaignRequestViewModel
    {
        public int CodesAmount { get; set; }
        public string SingleCode { get; set; }
        public CodeType CodeType { get; set; }
        public DiscountCampaignType DiscountCampaignType { get; set; }
        public decimal? DiscountValue { get; set; }
        public Guid? DiscountUnitId { get; set; }
        
        public DiscountCampaignApplyOn DiscountCampaignApplyOn { get; set; }
        public Guid? DiscountCampaignApplyOnId { get; set; }
        
        public List<DiscountValidationRequestViewModel> DiscountValidations { get; set; }
    }
}

