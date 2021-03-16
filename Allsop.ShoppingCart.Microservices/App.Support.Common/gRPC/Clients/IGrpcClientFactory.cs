using App.Support.Common.Protos.Catalog;

namespace App.Support.Common.gRPC.Clients
{
    public interface IGrpcClientFactory
    {
        CatalogGrpc.CatalogGrpcClient CreateCatalogGrpcClient();
    }
}