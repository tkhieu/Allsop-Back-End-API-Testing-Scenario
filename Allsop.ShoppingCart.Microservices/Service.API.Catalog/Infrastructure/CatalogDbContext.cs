using System;
using App.Support.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Service.API.Catalog.Infrastructure
{
    public class CatalogDbContext: DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category(){Id = new Guid().ToString(),Name = "A"}
                );
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}