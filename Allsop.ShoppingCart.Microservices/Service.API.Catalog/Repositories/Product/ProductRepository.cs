using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Service.API.Catalog.Infrastructure;

namespace Service.API.Catalog.Repositories.Product
{
    public class ProductRepository: IProductRepository
    {
        private readonly CatalogDbContext _context;
        
        public ProductRepository(CatalogDbContext context)
        {
            this._context = context;
        }
        
        public IEnumerable<App.Support.Common.Models.CatalogService.Product> GetProducts()
        {
            return _context.Products.Include("Category").ToList();
        }

        public App.Support.Common.Models.CatalogService.Product GetProductById(string productId)
        {
            return _context.Products.Include("Category").FirstOrDefault(p => p.Id == productId);
        }

        public void InsertProduct(App.Support.Common.Models.CatalogService.Product product)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProduct(App.Support.Common.Models.CatalogService.Product product)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public object GetProductsByCategoryId(string categoryId)
        {
            return _context.Products.Include("Category").Where(p => p.Category.Id == categoryId).ToList();
        }
    }
}