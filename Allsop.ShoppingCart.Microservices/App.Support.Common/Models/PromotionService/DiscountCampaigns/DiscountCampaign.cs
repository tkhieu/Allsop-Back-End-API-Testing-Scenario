using System;
using System.Collections.Generic;
using App.Support.Common.Models.PromotionService.DiscountCodes;
using App.Support.Common.Models.PromotionService.DiscountValidations;
using App.Support.Common.Models.PromotionService.Redemptions;
using App.Support.Common.Protos.Common;
using App.Support.Common.Protos.Promotion;
using Google.Protobuf.Collections;

namespace App.Support.Common.Models.PromotionService.DiscountCampaigns
{
    public class DiscountCampaign
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? DiscountValue { get; set; }
        public Guid? DiscountUnitId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        public DiscountCampaignType DiscountCampaignType { get; set; }
        
        public DiscountCampaignApplyOn DiscountCampaignApplyOn { get; set; }
        
        public Guid? ApplyOnId { get; set; }
        
        public string CodePrefix { get; set; }
        
        public virtual ICollection<DiscountCode> DiscountCodes { get; set; }
        public virtual ICollection<Redemption> Redemptions { get; set; }
        public virtual ICollection<DiscountValidation> DiscountValidations { get; set; }
        
        public DiscountCampaignDTO GenerateGrpcDtoFromDiscountCampaign()
        {
            var discountCampaignDto = new DiscountCampaignDTO
            {
                Id = this.Id.ToString(), Name = this.Name, 
            };
            
            var discountValue = this.DiscountValue;
            if (this.CodePrefix != null)
                discountCampaignDto.CodePrefix = CodePrefix;
            if (discountValue != null)
                discountCampaignDto.DiscountValue = DecimalValue.FromDecimal(discountValue.Value);
            discountCampaignDto.StartDate = this.StartDate.ToString();
            discountCampaignDto.ExpirationDate = this.ExpirationDate.ToString();
            discountCampaignDto.ApplyOnId = this.ApplyOnId.ToString();
            discountCampaignDto.DiscountCampaignType = (uint) this.DiscountCampaignType.GetHashCode();
            discountCampaignDto.DiscountUnitId = this.DiscountUnitId.ToString();
            discountCampaignDto.DiscountCampaignApplyOn = (uint) this.DiscountCampaignApplyOn.GetHashCode();
            
            foreach (var discountValidation in this.DiscountValidations)
            {
                var discountValidationDto = discountValidation.GenerateGrpcDtoFromProductValidation();
                discountCampaignDto.DiscountValidations.Add(discountValidationDto);
            }

            return discountCampaignDto;
        }
        
        public static DiscountCampaign GenerateDiscountCampaignFromGrpcDto(DiscountCampaignDTO productDto)
        {
            return new DiscountCampaign();
        }
    }
}