using System;
using System.Linq;
using App.Support.Common.Models;
using App.Support.Common.Models.CatalogService;
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
                
                new { Id = "34f98921-e46a-4937-872b-e2c57e705f3f",Name = "Cauliflower Florets", Packaging = "10 x 500g", OldPriceValue = 6.75m, PriceValue = 5.00m,     PriceUnit = "GBP" , InventoryQuantity = 5,  Sku="FV-000001", CategoryId = "fd6055d7-08a3-4351-8195-7da47e50f028" },
                
                new { Id = "77e63e97-b41a-4882-9574-52a3738fd93f",Name = "Coca-Cola",               Packaging = "6 x 2L",           OldPriceValue = 8.50m,  PriceValue = 8.30m,     PriceUnit = "GBP" , InventoryQuantity = 6,      Sku="DR-000001", CategoryId = "737c9710-e069-436a-a236-660e8277dedf" },
                new { Id = "d2fb685f-86dd-47ac-bb23-8ffd8ce84941",Name = "Still Mineral Water",     Packaging = "6 x 24 x 500ml",                           PriceValue = 21.75m,    PriceUnit = "GBP" , InventoryQuantity = 9,      Sku="DR-000002", CategoryId = "737c9710-e069-436a-a236-660e8277dedf" },
                new { Id = "bf7b5f89-a569-4e3d-acb8-04a07e1e1130",Name = "Sparkling Mineral Water", Packaging = "6 x 24 x 500ml",                           PriceValue = 25.83m,    PriceUnit = "GBP" , InventoryQuantity = 16,     Sku="DR-000003", CategoryId = "737c9710-e069-436a-a236-660e8277dedf" },
                
                new { Id = "5e0b02d5-a25f-4617-9215-3c646f9b4ae8",Name = "Plain Flour",             Packaging = "10 x 1kg",                                 PriceValue = 6.21m,     PriceUnit = "GBP" , InventoryQuantity = 4,     Sku="CI-000001", CategoryId = "3786f39a-a229-4689-aed7-d851082cd87a" },
                new { Id = "b0ad84dc-1df9-4e84-970e-d6e49dee87f3",Name = "Icing Sugar",             Packaging = "12 x 500g",                                PriceValue = 9.38m,     PriceUnit = "GBP" , InventoryQuantity = 6,     Sku="CI-000002", CategoryId = "3786f39a-a229-4689-aed7-d851082cd87a" },
                new { Id = "89090eed-5f8d-44bd-ac60-af45256c92ec",Name = "Free-Range Eggs",         Packaging = "10 x 12 each",                             PriceValue = 9.52m,     PriceUnit = "GBP" , InventoryQuantity = 9,     Sku="CI-000003", CategoryId = "3786f39a-a229-4689-aed7-d851082cd87a" },
                new { Id = "e337af6b-c746-4d04-9dac-f57cc52a6158",Name = "Caster Sugar",            Packaging = "16 x 750g",                                PriceValue = 12.76m,    PriceUnit = "GBP" , InventoryQuantity = 13,    Sku="CI-000004", CategoryId = "3786f39a-a229-4689-aed7-d851082cd87a" }
            );
            
            
            
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}