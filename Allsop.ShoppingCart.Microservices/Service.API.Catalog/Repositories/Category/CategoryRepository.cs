using System.Collections.Generic;
using System.Linq;
using Service.API.Catalog.Infrastructure;

namespace Service.API.Catalog.Repositories.Category
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly CatalogDbContext _context;

        public CategoryRepository(CatalogDbContext context)
        {
            this._context = context;
        }
        
        public IEnumerable<App.Support.Common.Models.CatalogService.Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public App.Support.Common.Models.CatalogService.Category GetCategoryById(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void InsertCategory(App.Support.Common.Models.CatalogService.Category category)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCategory(App.Support.Common.Models.CatalogService.Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}