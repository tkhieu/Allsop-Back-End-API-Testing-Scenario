using System;
using System.Linq;
using System.Threading.Tasks;
using App.Support.Common.Models.PromotionService.DiscountValidations;
using App.Support.Common.Protos.Cart;
using App.Support.Common.Protos.Common;
using App.Support.Common.Protos.Promotion;
using Grpc.Core;
using Service.API.Promotion.Repositories.DiscountCampaign;
using Service.API.Promotion.Repositories.DiscountCode;

namespace Service.API.Promotion.Services.gRPC
{
    public class PromotionGrpcService : PromotionGrpc.PromotionGrpcBase
    {
        private readonly DiscountCampaignRepository _discountCampaignRepository;
        private readonly DiscountCodeRepository _discountCodeRepository;

        public PromotionGrpcService(DiscountCampaignRepository discountCampaignRepository, DiscountCodeRepository discountCodeRepository)
        {
            _discountCampaignRepository = discountCampaignRepository;
            _discountCodeRepository = discountCodeRepository;
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
            var returnValidateDiscountCode = new ReturnValidateDiscountCode()
            {
                Status = GrpcStatus.Success
            };
            
            var validateDiscountCodeDto = new ValidateDiscountCodeDTO()
            {
                IsValid = true,
                Message = "Discount code is valid to use"
            };
            
            var discountCode = request.DiscountCode;
            var discountCodeObj = await _discountCodeRepository.GetDiscountCodeByCode(discountCode);

            if (discountCodeObj == null)
            {
                validateDiscountCodeDto = new ValidateDiscountCodeDTO()
                {
                    IsValid = false,
                    Message = "Error: Discount code is invalid to use"
                };

                returnValidateDiscountCode.ValidateDiscountCode = validateDiscountCodeDto;
                return returnValidateDiscountCode;
            }
            
            var discountCampaignId = discountCodeObj.DiscountCampaignId;
            var discountCampaignObj = await _discountCampaignRepository.GetById(discountCampaignId);

            var cartDto = request.Cart;
            
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
            var discountValidations = discountCampaignObj.GetSortedDiscountValidations();

            var productCatId = "";
            foreach (var discountValidation in discountValidations)
            {
                switch (discountValidation.ValueType)
                {
                    case DiscountValidationValueType.Bill:
                    {
                        var checkBillDiscountValidation = CheckBillDiscountValidation(discountValidation, cartDto);
                        if (checkBillDiscountValidation != null)
                        {
                            validateDiscountCodeDto = checkBillDiscountValidation;
                        }
                        break;
                    }
                    
                    case DiscountValidationValueType.ProductCat:
                    {
                        productCatId = CheckProductCategoryValidation(discountValidation);
                        break;
                    }
                    
                    case DiscountValidationValueType.Quantity:
                    {
                        var checkQuantityValidation  = CheckQuantityValidation(discountValidation, cartDto, productCatId);
                        if (checkQuantityValidation != null)
                        {
                            validateDiscountCodeDto = checkQuantityValidation;
                        }
                        break;
                    }
                    
                    case DiscountValidationValueType.SpendingAmount:
                    {
                        var checkSpendingAmountValidation = CheckSpendingAmountValidation(discountValidation, cartDto, productCatId);
                        if (checkSpendingAmountValidation != null)
                        {
                            validateDiscountCodeDto = checkSpendingAmountValidation;
                        }
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            // Return
            returnValidateDiscountCode.ValidateDiscountCode = validateDiscountCodeDto;
            return returnValidateDiscountCode;
        }

        private ValidateDiscountCodeDTO CheckSpendingAmountValidation(App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation discountValidation, CartDTO cartDto, string productCatId)
        {
            switch (discountValidation.Operator)
            {
                case DiscountValidationOperator.MoreThan:
                {
                    var productCatName = "";
                    var spendingAmount = 0m;
                    foreach (var cartItem in cartDto.CartItems)
                    {
                        if (cartItem.Product.Category.Id != productCatId) continue;
                        productCatName = cartItem.Product.Category.Name;
                        spendingAmount += cartItem.ItemSubTotalAmount.ToDecimal();
                    }

                    if (spendingAmount < decimal.Parse(discountValidation.Value))
                    {
                        return new ValidateDiscountCodeDTO()
                        {
                            IsValid = false,
                            Message = $"Spending amount of category {productCatName} less than discount code condition (> {discountValidation.Value})"
                        };
                    }
                    break;   
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return null;
        }

        private ValidateDiscountCodeDTO CheckQuantityValidation(App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation discountValidation, CartDTO cartDto, string productCatId)
        {
            switch (discountValidation.Operator)
            {
                case DiscountValidationOperator.MoreThan:
                {
                    var productCatName = "";
                    var count = 0L;
                    foreach (var cartItem in cartDto.CartItems)
                    {
                        if (cartItem.Product.Category.Id != productCatId) continue;
                        productCatName = cartItem.Product.Category.Name;
                        count += cartItem.Quantity;
                    }

                    if (count < int.Parse(discountValidation.Value))
                    {
                        return new ValidateDiscountCodeDTO()
                        {
                            IsValid = false,
                            Message = $"Product quantity of category {productCatName} less than discount code condition (> {discountValidation.Value})"
                        };
                    }
                                
                    break;   
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return null;
        }

        private string CheckProductCategoryValidation(App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation discountValidation)
        {
            switch (discountValidation.Operator)
            {
                case DiscountValidationOperator.Is:
                {
                    var productCatId = discountValidation.Value;
                    return productCatId;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private ValidateDiscountCodeDTO CheckBillDiscountValidation(App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation discountValidation, CartDTO cartDto)
        {
            switch (discountValidation.Operator)
            {
                case DiscountValidationOperator.MoreThan:
                {
                    if (cartDto.SubTotalAmount < decimal.Parse(discountValidation.Value))
                    {
                        return  new ValidateDiscountCodeDTO()
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

            return null;
        }
    }
}