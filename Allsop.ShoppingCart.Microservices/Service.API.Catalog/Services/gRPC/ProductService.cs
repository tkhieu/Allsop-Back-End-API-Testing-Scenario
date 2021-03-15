using System.Threading.Tasks;
using App.Support.Common.Protos.Catalog;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Service.API.Catalog.Services.gRPC
{
    public class ProductService : Product.ProductBase
    {
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public override Task<ReturnSingleProduct> GetProduct(GetSingleProductRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ReturnSingleProduct()
            {
            });
        }
    }
}