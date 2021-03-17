using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Support.Common.Protos.Cart;
using Google.Protobuf.Collections;

namespace App.Support.Common.Models.CartService
{
    [Table("Carts")]
    public class Cart
    {
        [Key]
        public string Id { get; init; }
        
        public Guid AccountId { get; init; }
        
        public DateTime CreatedAt { get; init; }

        public ICollection<CartItem> CartItems { get; set; }
        
        public string DiscountCode { get; set; }

        public CartDTO GenerateCartDto()
        {
            var cartDto = new CartDTO();
            cartDto.Id = this.Id;
            cartDto.AccountId = this.AccountId.ToString();
            cartDto.CreatedAt = this.CreatedAt.ToString();
            cartDto.DiscountCode = this.DiscountCode;

;            foreach (var cartItem in this.CartItems)
            {
                cartDto.CartItems.Add(cartItem.GenerateCartItemDto());
            }

            return cartDto;
        }
    }
}