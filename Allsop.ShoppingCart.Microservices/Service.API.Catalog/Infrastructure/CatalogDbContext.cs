using System;
using System.Linq;
using App.Support.Common.Models;
using Microsoft.EntityFrameworkCore;
using NodaMoney;

namespace Service.API.Catalog.Infrastructure
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = "5beff28e-bba2-4b1b-9f06-126d6365d4cf",Name = "Meat & Poultry", Code = "MP"},
                new Category() { Id = "fd6055d7-08a3-4351-8195-7da47e50f028",Name = "Fruit & Vegetables", Code = "FV"},
                new Category() { Id = "737c9710-e069-436a-a236-660e8277dedf",Name = "Drinks", Code = "DR"},
                new Category() { Id = "bae52764-af07-4043-8586-52816594ee86",Name = "Confectionary & Desserts", Code = "CD"},
                new Category() { Id = "3786f39a-a229-4689-aed7-d851082cd87a",Name = "Baking/Cooking Ingredients", Code = "CI"},
                new Category() { Id = "b5901197-4899-4a22-ad39-7f1f4cdcb84b",Name = "Miscellaneous Items", Code = "MI"}
            );
            
            modelBuilder.Entity<Product>().HasData(
                new { Id = "48d5553e-a450-4523-a143-73263766b62b",Name = "Chicken Fillets",     Packaging = "6 x 100g",                         PriceValue = 4.50m,     PriceUnit = "GBP" , InventoryQuantity = 12, Sku="MP-000001", CategoryId = "5beff28e-bba2-4b1b-9f06-126d6365d4cf" },
                new { Id = "e547f80c-55ff-4541-81e7-d84f55cfdae2",Name = "Sirloin Steaks",      Packaging = "4 x 6-8oz",                        PriceValue = 45.70m,    PriceUnit = "GBP" , InventoryQuantity = 6,  Sku="MP-000002", CategoryId = "5beff28e-bba2-4b1b-9f06-126d6365d4cf" },
                
                new { Id = "34f98921-e46a-4937-872b-e2c57e705f3f",Name = "Cauliflower Florets", Packaging = "10 x 500g", OldPriceValue = 6.75m, PriceValue = 5.00m,     PriceUnit = "GBP" , InventoryQuantity = 5,  Sku="FV-000001", CategoryId = "fd6055d7-08a3-4351-8195-7da47e50f028" }
            );
            
            
            
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}