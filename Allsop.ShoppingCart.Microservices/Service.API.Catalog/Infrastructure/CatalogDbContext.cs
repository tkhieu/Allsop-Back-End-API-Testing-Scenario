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
                new Category() { Id = Guid.NewGuid().ToString(),Name = "Meat & Poultry", Code = "MP"},
                new Category() { Id = Guid.NewGuid().ToString(),Name = "Fruit & Vegetables", Code = "FV"},
                new Category() { Id = Guid.NewGuid().ToString(),Name = "Drinks", Code = "DR"},
                new Category() { Id = Guid.NewGuid().ToString(),Name = "Confectionary & Desserts", Code = "CD"},
                new Category() { Id = Guid.NewGuid().ToString(),Name = "Baking/Cooking Ingredients", Code = "CI"},
                new Category() { Id = Guid.NewGuid().ToString(),Name = "Miscellaneous Items", Code = "MI"}
            );
            
            // modelBuilder.Entity<Product>().HasData(
            //     new Product() { Id = Guid.NewGuid().ToString(),Name = "Chicken Fillets", Packaging = "6 x 100g", Price =  (new Money(4.50m, "GBP")).ToString(), InventoryQuantity = 12}
            // );
            //
            // modelBuilder.Entity<Product>().HasData(
            //     new Product() { Id = Guid.NewGuid().ToString(),Name = "Chicken Fillets2", Packaging = "6 x 100g", Price =  (new Money(4.50m, "GBP")).ToString(), InventoryQuantity = 12}
            // );
            //
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}