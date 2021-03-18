namespace App.Support.Common.Models.PromotionService.DiscountCampaigns
{
    public enum DiscountCampaignType
    {
        Money = 1,
        Percentage = 2,
        Product = 3,
        None = 0
    }
    
    public static class DiscountCampaignTypeEnum
    {
        public static DiscountCampaignType Convert(int discountCampaignTypeInt)
        {
            return discountCampaignTypeInt switch
            {
                1 => DiscountCampaignType.Money,
                2 => DiscountCampaignType.Percentage,
                3 => DiscountCampaignType.Product,
                _ => DiscountCampaignType.None
            };
        }
    }
}