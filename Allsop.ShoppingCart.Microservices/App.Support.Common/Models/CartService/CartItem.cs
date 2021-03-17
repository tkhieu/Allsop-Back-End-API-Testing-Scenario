using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Support.Common.Models.CartService
{
    [Table("CartItems")]
    public class CartItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; init; }
        
        public string ProductId { get; init; }
        
        public long Quantity { get; set; }
        
        public DateTime AddedAt { get; set; }

        public string CartId { get; set; }
    }
}