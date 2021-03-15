using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Support.Common.Models
{
    [Table("CartItems")]
    public class CartItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; init; }
        
        public Guid ProductId { get; init; }
        
        public long Quantity { get; init; }
        
        public DateTime AddedAt { get; set; }

        public Cart Cart { get; set; }
    }
}