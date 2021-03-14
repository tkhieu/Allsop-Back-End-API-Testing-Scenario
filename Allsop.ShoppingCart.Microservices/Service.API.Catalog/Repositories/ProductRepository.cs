using System.Collections.Generic;
using System.Linq;
using App.Support.Common.Models;
using Microsoft.EntityFrameworkCore;
using Service.API.Catalog.Infrastructure;

namespace Service.API.Catalog.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private CatalogDbContext _context;
        
        public ProductRepository(CatalogDbContext context)
        {
            this._context = context;
        }
        
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include("Category").ToList();
        }

        public Product GetProductById(int productId)
        {
            throw new System.NotImplementedException();
        }

        public void InsertProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProduct(Product product)
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