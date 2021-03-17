using System.Collections.Generic;

namespace Service.API.Catalog.Repositories.Category
{
    public interface ICategoryRepository
    {
        IEnumerable<App.Support.Common.Models.CatalogService.Category> GetCategories();
        App.Support.Common.Models.CatalogService.Category GetCategoryById(int categoryId);
        void InsertCategory(App.Support.Common.Models.CatalogService.Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(App.Support.Common.Models.CatalogService.Category category);
        void Save();
    }
}