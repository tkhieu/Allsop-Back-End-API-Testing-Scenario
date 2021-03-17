using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.API.Promotion.ViewModels
{
    public class DiscountCampaignViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Discount Unit field is required")]
        public string DiscountUnit { get; set; }
        public int DiscountValue { get; set; }
        public Guid? DiscountUnitId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        public string CampaignType { get; set; }
        public int Status { get; set; }
        public string ApplyOn { get; set; }
        public Guid? ApplyOnId { get; set; }
        public string CodePrefix { get; set; }
        [NotMapped]
        public int CodesCount { get; set; }
        [NotMapped]
        public int RedemptionsCount { get; set; }

        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
    }
}