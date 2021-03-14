using System.Collections.Generic;

namespace Service.API.Catalog.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<App.Support.Common.Models.Category> GetCategories();
        App.Support.Common.Models.Category GetCategoryById(int categoryId);
        void InsertCategory(App.Support.Common.Models.Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(App.Support.Common.Models.Category category);
        void Save();
    }
}