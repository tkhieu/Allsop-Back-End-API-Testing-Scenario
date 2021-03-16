using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using App.Support.Common.Protos.Catalog;
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
        
        public Decimal? OldPriceValue { get; set; }
        
        public string PriceUnit { get; set; }
        
        public int InventoryQuantity { get; set; }

        public Protos.Catalog.ProductDTO GenerateGrpcProduct()
        {
            var category = this.Category;

            var c = new CategoryDTO()
            {
                Id = category.Id,
                Code = category.Code,
                Name = category.Name
            };
            
            var p = new ProductDTO()
            {
                Id = this.Id,
                Name = this.Name,
                InventoryQuantity = this.InventoryQuantity,
                Packaging = this.Packaging,
                PriceUnit = this.PriceUnit,
                Sku = this.Sku,
                Category = c
            };

            return p;
        }
    }
}