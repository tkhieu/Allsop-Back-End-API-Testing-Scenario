using System.Collections.Generic;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;

namespace Service.API.Promotion.ViewModels
{
    public class DiscountCampaignRequestViewModel
    {
        public int CodesAmount { get; set; }
        public string SingleCode { get; set; }
        public CodeType CodeType { get; set; }
        public List<DiscountValidationRequestViewModel> DiscountValidations { get; set; }
    }
}

