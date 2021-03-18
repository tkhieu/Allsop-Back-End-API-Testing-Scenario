using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Services.DiscountValidation
{
    public interface IDiscountValidationService
    {
        App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation
            GenerateDiscountValidationFromViewModel(DiscountValidationRequestViewModel viewModel);

    }
}