using App.Support.Common.Protos.Catalog;
using Grpc.Net.Client;

namespace App.Support.Common.gRPC.Clients
{
    public class GrpcClientFactory: IGrpcClientFactory
    {
        public CatalogGrpc.CatalogGrpcClient CreateCatalogGrpcClient()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:6001");
            var client = new CatalogGrpc.CatalogGrpcClient(channel);
            return client;
        }
    }
}