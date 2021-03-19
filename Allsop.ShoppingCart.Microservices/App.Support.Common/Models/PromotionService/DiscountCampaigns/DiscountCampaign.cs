using System;
using System.Collections.Generic;
using System.Linq;
using App.Support.Common.Models.PromotionService.DiscountCodes;
using App.Support.Common.Models.PromotionService.DiscountValidations;
using App.Support.Common.Models.PromotionService.Redemptions;
using App.Support.Common.Protos.Common;
using App.Support.Common.Protos.Promotion;

namespace App.Support.Common.Models.PromotionService.DiscountCampaigns
{
    public sealed class DiscountCampaign
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
        
        public ICollection<DiscountCode> DiscountCodes { get; set; }
        public ICollection<Redemption> Redemptions { get; set; }

        public ICollection<DiscountValidation> DiscountValidations { get; set; }

        public IOrderedEnumerable<DiscountValidation> GetSortedDiscountValidations()
        {
            return DiscountValidations.OrderBy(p => p.Priority);
        }

        public DiscountCampaignDTO GenerateGrpcDtoFromDiscountCampaign()
        {
            var discountCampaignDto = new DiscountCampaignDTO
            {
                Id = Id.ToString(), Name = Name, 
            };
            
            var discountValue = DiscountValue;
            if (CodePrefix != null)
                discountCampaignDto.CodePrefix = CodePrefix;
            if (discountValue != null)
                discountCampaignDto.DiscountValue = DecimalValue.FromDecimal(discountValue.Value);
            discountCampaignDto.StartDate = StartDate.ToString();
            discountCampaignDto.ExpirationDate = ExpirationDate.ToString();
            discountCampaignDto.ApplyOnId = ApplyOnId.ToString();
            discountCampaignDto.DiscountCampaignType = (uint) DiscountCampaignType.GetHashCode();
            discountCampaignDto.DiscountUnitId = DiscountUnitId.ToString();
            discountCampaignDto.DiscountCampaignApplyOn = (uint) DiscountCampaignApplyOn.GetHashCode();
            
            foreach (var discountValidation in DiscountValidations)
            {
                var discountValidationDto = discountValidation.GenerateGrpcDtoFromProductValidation();
                discountCampaignDto.DiscountValidations.Add(discountValidationDto);
            }

            return discountCampaignDto;
        }
        
        public static DiscountCampaign GenerateDiscountCampaignFromGrpcDto(DiscountCampaignDTO discountCampaignDto)
        {
            var discountCampaign = new DiscountCampaign
            {
                Id = Guid.Parse(discountCampaignDto.Id),
                Name = discountCampaignDto.Name,
                CodePrefix = discountCampaignDto.CodePrefix,
                DiscountValue = discountCampaignDto.DiscountValue.ToDecimal(),
                ExpirationDate = DateTimeOffset.Parse(discountCampaignDto.ExpirationDate),
                StartDate = DateTimeOffset.Parse(discountCampaignDto.StartDate)
            };
            
            if(!discountCampaignDto.ApplyOnId.Equals(""))
                discountCampaign.ApplyOnId = Guid.Parse(discountCampaignDto.ApplyOnId);
            if(!discountCampaignDto.DiscountUnitId.Equals(""))
                discountCampaign.DiscountUnitId = Guid.Parse(discountCampaignDto.DiscountUnitId);

            discountCampaign.DiscountCampaignType =
                DiscountCampaignTypeEnum.Convert((int)discountCampaignDto.DiscountCampaignType);

            discountCampaign.DiscountCampaignApplyOn =
                DiscountCampaignApplyOnEnum.Convert((int) discountCampaignDto.DiscountCampaignApplyOn);
            return discountCampaign;
        }
    }
}