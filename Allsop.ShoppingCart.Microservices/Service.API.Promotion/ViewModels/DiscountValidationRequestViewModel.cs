using App.Support.Common.Models.PromotionService.DiscountValidations;

namespace Service.API.Promotion.ViewModels
{
    public class DiscountValidationRequestViewModel
    {
        public DiscountValidationOperator Operator { get; set; }
        public DiscountValidationValueType ValueType { get; set; }
        public string Value { get; set; }
        
        public int Priority { get; set; }
        
    }
}