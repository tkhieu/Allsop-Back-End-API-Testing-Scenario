using App.Support.Common.Models;
using App.Support.Common.ViewModels;

namespace Service.API.Cart.ViewModels.Cart
{
    public class AdjustCartItemViewModel
    {
        public string ProductId { get; set; }
        public long Quantity { get; set; }
    }
    
    public class DeleteCartItemViewModel
    {
        public string ProductId { get; set; }
    }
}