using System;
using System.Collections.Generic;
using App.Support.Common.Models.CartService;
using App.Support.Common.Models.CatalogService;
using App.Support.Common.Protos.Promotion;
using NodaMoney;

namespace Service.API.Cart.ViewModels.Cart
{
    public class CartViewModel
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<CartItemViewModel> CartItems { get; set; }
        
        public string DiscountCode { get; set; }
        
        public DiscountCampaignDTO DiscountCampaignDto { get; set; }
        
        public decimal SubTotalAmount { get; set; }
        
        public decimal DiscountAmount { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public string AmountUnit { get; set; }

        public CartViewModel(App.Support.Common.Models.CartService.Cart cart)
        {

            Id = Guid.Parse(cart.Id);

            AccountId = cart.AccountId;

            CreatedAt = cart.CreatedAt;

            CartItems = new List<CartItemViewModel>();

            DiscountCode = cart.DiscountCode;

            var subTotalAmount = 0m;
            
            foreach (var cartItem in cart.CartItems)
            {
                CartItems.Add(new CartItemViewModel(cartItem));
                subTotalAmount += cartItem.Product.PriceValue;
            }

            SubTotalAmount = subTotalAmount;

            TotalAmount = SubTotalAmount - DiscountAmount;
        }
    }

    public class CartItemViewModel
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public long Quantity { get; set; }

        public DateTime AddedAt { get; set; }
        
        public Money ItemSubTotalAmount { get; set; }
        
        public Money ItemDiscountAmount { get; set; }
        
        public Money ItemTotalAmount { get; set; }

        public CartItemViewModel(CartItem cartItem)
        {
            Id = cartItem.Id;

            ProductId = cartItem.ProductId;

            Quantity = cartItem.Quantity;

            AddedAt = cartItem.AddedAt;
        }
    }


    public class AdjustCartItemRequestViewModel
    {
        public string ProductId { get; set; }
        public long Quantity { get; set; }
    }
    
    public class DeleteCartItemRequestViewModel
    {
        public string ProductId { get; set; }
    }
}