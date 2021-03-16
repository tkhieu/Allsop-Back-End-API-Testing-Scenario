using System.Threading.Tasks;
using App.Support.Common.Protos.Catalog;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Service.API.Catalog.Repositories.Product;

namespace Service.API.Catalog.Services.gRPC
{
    public class ProductService : ProductGrpc.ProductGrpcBase
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;

        public ProductService(ILogger<ProductService> logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public override Task<ReturnSingleProduct> GetProduct(GetSingleProductRequest request, ServerCallContext context)
        {
            var product = _productRepository.GetProductById(request.Id);

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