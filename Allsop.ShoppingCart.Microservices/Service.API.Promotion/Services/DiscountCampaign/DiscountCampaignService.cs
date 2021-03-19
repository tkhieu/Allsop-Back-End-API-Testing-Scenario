using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Support.Common.Models.PromotionService.DiscountCampaigns;
using Service.API.Promotion.Repositories.DiscountCampaign;
using Service.API.Promotion.Repositories.DiscountCode;
using Service.API.Promotion.Services.DiscountCode;
using Service.API.Promotion.Services.DiscountValidation;
using Service.API.Promotion.ViewModels;

namespace Service.API.Promotion.Services.DiscountCampaign
{
    public class DiscountCampaignService: IDiscountCampaignService
    {
        private readonly IDiscountValidationService _discountValidationService;
        private readonly IDiscountCodeService _discountCodeService;
        private readonly IDiscountCampaignRepository _discountCampaignRepository;
        private readonly IDiscountCodeRepository _discountCodeRepository;

        public DiscountCampaignService(DiscountValidationService discountValidationService, 
            DiscountCodeService discountCodeService, 
            DiscountCampaignRepository discountCampaignRepository,
            DiscountCodeRepository discountCodeRepository)
        {
            _discountValidationService = discountValidationService;
            _discountCodeService = discountCodeService;
            _discountCampaignRepository = discountCampaignRepository;
            _discountCodeRepository = discountCodeRepository;
        }
        
        public App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign GenerateDiscountCampaignFromViewModel(DiscountCampaignRequestViewModel viewModel)
        {
            var discountCampaign =
                new App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign
                {
                    Id = Guid.NewGuid(),
                    Name = viewModel.Name,
                    DiscountCampaignType = viewModel.DiscountCampaignType,
                    DiscountValue = viewModel.DiscountValue,
                    DiscountUnitId = viewModel.DiscountUnitId,
                    StartDate = viewModel.StartDate,
                    ExpirationDate = viewModel.ExpirationDate,
                    DiscountCampaignApplyOn = viewModel.DiscountCampaignApplyOn,
                    ApplyOnId = viewModel.DiscountCampaignApplyOnId,
                    CodePrefix = viewModel.CodePrefix
                };

            discountCampaign.DiscountValidations =
                new List<App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation>();
            foreach (var discountValidation in viewModel.DiscountValidations.Select(viewModelDiscountValidation => _discountValidationService.GenerateDiscountValidationFromViewModel(viewModelDiscountValidation)))
            {
                discountCampaign.DiscountValidations.Add(discountValidation);
            }

            var discountCodes = _discountCodeService.GenerateDiscountCodesFromDiscountCampaignViewModel(viewModel);
            discountCampaign.DiscountCodes = discountCodes;

            return discountCampaign;
        }

        public async Task<bool> CheckDuplicateCampaign(DiscountCampaignRequestViewModel discountCampaignRequestViewModel)
        {
            switch (discountCampaignRequestViewModel.CodeType)
            {
                case CodeType.BulkCodes:
                {
                    var discountCampaign = await _discountCampaignRepository.GetByCodePrefix(discountCampaignRequestViewModel.CodePrefix);
                    if (discountCampaign != null) return true;
                }
                    break;
                case CodeType.SingleCode:
                {
                    var discountCode =
                        await _discountCodeRepository.GetDiscountCodeByCode(discountCampaignRequestViewModel
                            .SingleCode);
                    if (discountCode != null) return true;
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return false;
        }
    }
}