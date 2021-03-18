namespace App.Support.Common.Models.PromotionService.DiscountCampaigns
{
    public enum DiscountCampaignApplyOn
    {
        Bill = 1,
        Product = 2,
        ProductCategory = 3,
        None = 0
    }
    
    public static class DiscountCampaignApplyOnEnum
    {
        public static DiscountCampaignApplyOn Convert(int discountCampaignApplyOnInt)
        {
            return discountCampaignApplyOnInt switch
            {
                1 => DiscountCampaignApplyOn.Bill,
                2 => DiscountCampaignApplyOn.Product,
                3 => DiscountCampaignApplyOn.ProductCategory,
                _ => DiscountCampaignApplyOn.None
            };
        }
    }
}