using App.Support.Common.Protos.Catalog;
using App.Support.Common.Protos.Promotion;
using Grpc.Net.Client;

namespace App.Support.Common.gRPC.Clients
{
    public class GrpcClientFactory: IGrpcClientFactory
    {
        public CatalogGrpc.CatalogGrpcClient CreateCatalogGrpcClient()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:6001");
            var client = new CatalogGrpc.CatalogGrpcClient(channel);
            return client;
        }

        public PromotionGrpc.PromotionGrpcClient CreatePromotionGrpcClient()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:6004");
            var client = new PromotionGrpc.PromotionGrpcClient(channel);
            return client;
        }
    }
}