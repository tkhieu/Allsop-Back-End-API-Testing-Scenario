using System;
using App.Support.Common.Protos.Promotion;

namespace App.Support.Common.Models.PromotionService.DiscountValidations
{
    public class DiscountValidation
    {
        public Guid Id { get; set; }
        public DiscountValidationOperator Operator { get; set; }
        public DiscountValidationValueType ValueType { get; set; }
        public string Value { get; set; }
        public Guid DiscountCampaignId { get; set; }


        public DiscountValidationDTO GenerateGrpcDtoFromProductValidation()
        {
            var discountValidationDto = new DiscountValidationDTO();
            discountValidationDto.Id = Id.ToString();
            discountValidationDto.Operator = (uint) this.Operator.GetHashCode();
            discountValidationDto.Value = this.Value;
            discountValidationDto.ValueType = (uint) this.ValueType.GetHashCode();
            discountValidationDto.DiscountCampaignId = this.DiscountCampaignId.ToString();

            return discountValidationDto;

        }
    }
}