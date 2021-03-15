using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Support.Common.Models
{
    [Table("Carts")]
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; init; }
        
        public Guid AccountId { get; init; }
        
        public DateTime CreatedAt { get; init; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}