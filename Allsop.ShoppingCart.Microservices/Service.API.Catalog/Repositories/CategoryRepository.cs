using System.Collections.Generic;
using System.Linq;
using App.Support.Common.Models;
using Service.API.Catalog.Infrastructure;

namespace Service.API.Catalog.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private CatalogDbContext _context;

        public CategoryRepository(CatalogDbContext context)
        {
            this._context = context;
        }
        
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void InsertCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}