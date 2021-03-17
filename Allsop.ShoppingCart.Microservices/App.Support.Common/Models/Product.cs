using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Support.Common.Protos.Catalog;
using App.Support.Common.Protos.Common;

namespace App.Support.Common.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Packaging { get; set; }
        
        public string Sku { get; set; }
        
        public Category Category { get; set; }
        
        public decimal PriceValue { get; set; }
        
        public Decimal? OldPriceValue { get; set; }
        
        public string PriceUnit { get; set; }
        
        public int InventoryQuantity { get; set; }

        public ProductDTO GenerateGrpcProduct()
        {
            var category = Category;

            var c = new CategoryDTO
            {
                Id = category.Id,
                Code = category.Code,
                Name = category.Name
            };
            
            var p = new ProductDTO
            {
                Id = Id,
                Name = Name,
                InventoryQuantity = InventoryQuantity,
                Packaging = Packaging,
                PriceUnit = PriceUnit,
                PriceValue = DecimalValue.FromDecimal(PriceValue),
                
                Sku = Sku,
                Category = c
            };

            if (OldPriceValue.HasValue)
            {
                p.OldPriceValue = DecimalValue.FromDecimal(OldPriceValue.Value);
            }

            return p;
        }
        
        public static Product GenerateProductFromGrpcDto(ProductDTO productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Packaging = productDto.Packaging,
                Sku = productDto.Sku,
                InventoryQuantity = productDto.InventoryQuantity,
                PriceUnit = productDto.PriceUnit,
                PriceValue = productDto.PriceValue.ToDecimal(),
            };

            var category = new Category()
            {
                Id = productDto.Category.Id,
                Code = productDto.Category.Code,
                Name = productDto.Category.Name
            };

            product.Category = category;
            
            if (productDto.OldPriceValue != null)
            {
                product.OldPriceValue = productDto.OldPriceValue.ToDecimal();
            }

            return product;
        }
    }
}