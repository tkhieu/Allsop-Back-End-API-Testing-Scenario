namespace App.Support.Common.Models.PromotionService.DiscountValidations
{
    public enum DiscountValidationValueType
    {
        Bill = 1,
        Quantity = 2,
        SpendingAmount = 3,
        Product = 4,
        ProductCat = 5,
        DateTime = 6,
        
        RedeemsTime = 7,
        RedeemsPerUser = 8,
        RedeemsPerUserPerDay = 9,
        
        
        TotalDiscountAmount = 10
    }
    
    public enum DiscountValidationOperator
    {
        Is = 1,
        MoreThan = 2,
        LessThan = 3,
        Before = 4
    }
}