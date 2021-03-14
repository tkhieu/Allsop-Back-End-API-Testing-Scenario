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
        
        private DbSet<Category> Categories;
    }
}