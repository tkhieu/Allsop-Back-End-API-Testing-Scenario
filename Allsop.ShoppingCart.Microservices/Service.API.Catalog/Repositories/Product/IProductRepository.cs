using System.Collections.Generic;

namespace Service.API.Catalog.Repositories.Product
{
    public interface IProductRepository
    {
        IEnumerable<App.Support.Common.Models.Product> GetProducts();
        App.Support.Common.Models.Product GetProductById(int productId);
        void InsertProduct(App.Support.Common.Models.Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(App.Support.Common.Models.Product product);
        void Save();
        object GetProductsByCategoryId(string categoryId);
    }
}