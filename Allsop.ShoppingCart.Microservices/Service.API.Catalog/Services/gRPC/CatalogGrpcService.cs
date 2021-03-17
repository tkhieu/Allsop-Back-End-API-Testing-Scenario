using System.Threading.Tasks;
using App.Support.Common.Protos.Catalog;
using App.Support.Common.Protos.Common;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Service.API.Catalog.Repositories.Product;

namespace Service.API.Catalog.Services.gRPC
{
    public class CatalogGrpcService : CatalogGrpc.CatalogGrpcBase
    {
        private readonly ILogger<CatalogGrpcService> _logger;
        private readonly IProductRepository _productRepository;

        public CatalogGrpcService(ILogger<CatalogGrpcService> logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public override Task<ReturnSingleProduct> GetProduct(GetSingleProductRequest request, ServerCallContext context)
        {
            var product = _productRepository.GetProductById(request.ProductId);

            if (product == null)
                return Task.FromResult(new ReturnSingleProduct()
                {
                    Status = GrpcStatus.Error,
                    Product = null
                });
            
            
            var productDto = product.GenerateGrpcProduct();
            return Task.FromResult(new ReturnSingleProduct()
            {
                Status = GrpcStatus.Success,
                Product = productDto
            });
        }
    }
}