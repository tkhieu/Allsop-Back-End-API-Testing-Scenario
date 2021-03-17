using App.Support.Common.Protos.Catalog;
using App.Support.Common.Protos.Promotion;

namespace App.Support.Common.gRPC.Clients
{
    public interface IGrpcClientFactory
    {
        CatalogGrpc.CatalogGrpcClient CreateCatalogGrpcClient();
        PromotionGrpc.PromotionGrpcClient CreatePromotionGrpcClient();
    }
}