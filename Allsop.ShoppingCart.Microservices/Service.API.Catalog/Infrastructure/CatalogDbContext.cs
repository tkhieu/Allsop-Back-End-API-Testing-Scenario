using System;
using App.Support.Common.Models;
using Microsoft.EntityFrameworkCore;

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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}