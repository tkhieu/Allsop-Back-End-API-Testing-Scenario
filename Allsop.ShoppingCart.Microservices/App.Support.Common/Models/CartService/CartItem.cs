using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Support.Common.Models.CatalogService;
using App.Support.Common.Protos.Cart;
using App.Support.Common.Protos.Common;

namespace App.Support.Common.Models.CartService
{
    [Table("CartItems")]
    public class CartItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; init; }
        
        public Guid ProductId { get; set; }
        
        public long Quantity { get; set; }
        
        public DateTime AddedAt { get; set; }

        public string CartId { get; set; }
    }
}