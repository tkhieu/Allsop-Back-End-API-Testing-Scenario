using System;
using System.Threading.Tasks;
using App.Support.Common.Models.PromotionService.DiscountValidations;
using App.Support.Common.Protos.Common;
using App.Support.Common.Protos.Promotion;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Service.API.Promotion.Repositories.DiscountCampaign;
using Service.API.Promotion.Repositories.DiscountCode;

namespace Service.API.Promotion.Services.gRPC
{
    public class PromotionGrpcService : PromotionGrpc.PromotionGrpcBase
    {
        private readonly DiscountCampaignRepository _discountCampaignRepository;
        private readonly DiscountCodeRepository _discountCodeRepository;
        private readonly ILogger<PromotionGrpcService> _logger;

        public PromotionGrpcService(ILogger<PromotionGrpcService> logger,
            DiscountCampaignRepository discountCampaignRepository, DiscountCodeRepository discountCodeRepository)
        {
            _discountCampaignRepository = discountCampaignRepository;
            _discountCodeRepository = discountCodeRepository;
            _logger = logger;
        }

        public override async Task<ReturnSingleDiscountCampaign> GetDiscountDetail(
            GetDiscountCampaignDetailRequest request, ServerCallContext context)
        {
            var discountCode = request.DiscountCode;

            var discountCodeObj = await _discountCodeRepository.GetDiscountCodeByCode(discountCode);

            var discountCampaignId = discountCodeObj.DiscountCampaignId;

            var discountCampaignObj = await _discountCampaignRepository.GetById(discountCampaignId);

            var discountCampaignDto = discountCampaignObj.GenerateGrpcDtoFromDiscountCampaign();

            var returnSingleDiscountCampaign = new ReturnSingleDiscountCampaign
            {
                Status = GrpcStatus.Success,
                DiscountCampaign = discountCampaignDto
            };

            return returnSingleDiscountCampaign;
        }

        public override async Task<ReturnValidateDiscountCode> ValidateDiscountCode(ValidateDiscountCodeWithCartRequest request, ServerCallContext context)
        {
            var discountCode = request.DiscountCode;
            
            var discountCodeObj = await _discountCodeRepository.GetDiscountCodeByCode(discountCode);
            
            var discountCampaignId = discountCodeObj.DiscountCampaignId;

            var discountCampaignObj = await _discountCampaignRepository.GetById(discountCampaignId);

            var cartDto = request.Cart;

            var validateDiscountCodeDto = new ValidateDiscountCodeDTO()
            {
                IsValid = true,
                Message = "Discount code is valid to use"
            };
            
            
            // Check redemptionCount
            var redemptionsCount = discountCodeObj.Redemptions?.Count ?? 0;
            
            if (discountCodeObj.MaxRedeem == redemptionsCount)
            {
                validateDiscountCodeDto = new ValidateDiscountCodeDTO()
                {
                    IsValid = false,
                    Message = "This code already excess max redemption"
                };
            }
            // Check expirationDate
            if (discountCampaignObj.ExpirationDate < DateTime.Now)
            {
                validateDiscountCodeDto = new ValidateDiscountCodeDTO()
                {
                    IsValid = false,
                    Message = "This code already expired"
                };
            }
            
            // Check startDate
            if (discountCampaignObj.StartDate > DateTime.Now)
            {
                validateDiscountCodeDto = new ValidateDiscountCodeDTO()
                {
                    IsValid = false,
                    Message = "This campaign not yet start"
                };
            }

            // Check discountValidations
            var discountValidations = discountCampaignObj.DiscountValidations;

            var productCatId = "";
            var productCatName = "";
            foreach (var discountValidation in discountValidations)
            {
                switch (discountValidation.ValueType)
                {
                    case DiscountValidationValueType.Bill:
                    {
                        switch (discountValidation.Operator)
                        {
                            case DiscountValidationOperator.MoreThan:
                            {
                                if (cartDto.SubTotalAmount < decimal.Parse(discountValidation.Value))
                                {
                                    validateDiscountCodeDto = new ValidateDiscountCodeDTO()
                                    {
                                        IsValid = false,
                                        Message = "Subtotal amount less than discount code condition"
                                    };
                                }
                                break;   
                            }
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    }
                    
                    case DiscountValidationValueType.ProductCat:
                    {
                        switch (discountValidation.Operator)
                        {
                            case DiscountValidationOperator.Is:
                            {
                                productCatId = discountValidation.Value;
                                break;   
                            }
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    }
                    
                    case DiscountValidationValueType.Quantity:
                    {
                        switch (discountValidation.Operator)
                        {
                            case DiscountValidationOperator.MoreThan:
                            {

                                var count = 0L;
                                foreach (var cartItem in cartDto.CartItems)
                                {
                                    if (cartItem.Product.Category.Id != productCatId) continue;
                                    productCatName = cartItem.Product.Category.Name;
                                    count += cartItem.Quantity;
                                }

                                if (count < int.Parse(discountValidation.Value))
                                {
                                    validateDiscountCodeDto = new ValidateDiscountCodeDTO()
                                    {
                                        IsValid = false,
                                        Message = $"Product quantity of category {productCatName} less than discount code condition"
                                    };
                                }
                                
                                break;   
                            }
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    }
                    
                    case DiscountValidationValueType.SpendingAmount:
                    {
                        switch (discountValidation.Operator)
                        {
                            case DiscountValidationOperator.MoreThan:
                            {
                                
                                var spendingAmount = 0m;
                                foreach (var cartItem in cartDto.CartItems)
                                {
                                    if (cartItem.Product.Category.Id != productCatId) continue;
                                    productCatName = cartItem.Product.Category.Name;
                                    spendingAmount += cartItem.ItemSubTotalAmount.ToDecimal();
                                }

                                if (spendingAmount < decimal.Parse(discountValidation.Value))
                                {
                                    validateDiscountCodeDto = new ValidateDiscountCodeDTO()
                                    {
                                        IsValid = false,
                                        Message = $"Spending amount of category {productCatName} less than discount code condition"
                                    };
                                }
                                break;   
                            }
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }


            // Return
            var returnValidateDiscountCode = new ReturnValidateDiscountCode()
            {
                Status = GrpcStatus.Success,
                ValidateDiscountCode = validateDiscountCodeDto
            };
            return returnValidateDiscountCode;
        }
    }
}