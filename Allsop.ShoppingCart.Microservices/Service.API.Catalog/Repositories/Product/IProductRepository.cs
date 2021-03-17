using System.Collections.Generic;

namespace Service.API.Catalog.Repositories.Product
{
    public interface IProductRepository
    {
        IEnumerable<App.Support.Common.Models.CatalogService.Product> GetProducts();
        App.Support.Common.Models.CatalogService.Product GetProductById(string productId);
        void InsertProduct(App.Support.Common.Models.CatalogService.Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(App.Support.Common.Models.CatalogService.Product product);
        void Save();
        object GetProductsByCategoryId(string categoryId);
    }
}