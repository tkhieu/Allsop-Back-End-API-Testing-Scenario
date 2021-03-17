using System;
using System.Collections.Generic;
using App.Support.Common.Models;
using App.Support.Common.Models.CartService;
using App.Support.Common.Models.CatalogService;

namespace Service.API.Cart.ViewModels.Cart
{
    public class CartViewModel
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<CartItemViewModel> CartItems { get; set; }

        public CartViewModel(App.Support.Common.Models.CartService.Cart cart)
        {

            this.Id = Guid.Parse(cart.Id);

            this.AccountId = cart.AccountId;

            this.CreatedAt = cart.CreatedAt;

            this.CartItems = new List<CartItemViewModel>();
            
            foreach (var cartItem in cart.CartItems)
            {
                this.CartItems.Add(new CartItemViewModel(cartItem));
            }
        }
    }

    public class CartItemViewModel
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public long Quantity { get; set; }

        public DateTime AddedAt { get; set; }

        public CartItemViewModel(CartItem cartItem)
        {
            this.Id = Guid.Parse(cartItem.Id);

            this.ProductId = Guid.Parse(cartItem.ProductId);

            this.Quantity = cartItem.Quantity;

            this.AddedAt = cartItem.AddedAt;
        }
    }
}