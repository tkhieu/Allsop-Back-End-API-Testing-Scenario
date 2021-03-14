using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using NodaMoney;

namespace App.Support.Common.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; init; }
        
        public string Name { get; init; }
        
        public string Packaging { get; init; }
        
        public string Sku { get; init; }
        
        public Category Category { get; set; }
        
        public decimal PriceValue { get; set; }
        
        public string PriceUnit { get; set; }
        
        public int InventoryQuantity { get; set; }
    }
}