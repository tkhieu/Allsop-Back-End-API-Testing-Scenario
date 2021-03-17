using System;
using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Services.DiscountValidation
{
    public class DiscountValidationService: IDiscountValidationService
    {
        public App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation GenerateDiscountValidationFromViewModel(DiscountValidationRequestViewModel viewModel)
        {
            var discountValidation =
                new App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation
                {
                    Id = Guid.NewGuid(),
                    Operator = viewModel.Operator,
                    ValueType = viewModel.ValueType,
                    Value = viewModel.Value
                };
            
            return discountValidation;
        }
    }
}