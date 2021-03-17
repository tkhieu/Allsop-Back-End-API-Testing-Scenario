using System.Threading.Tasks;
using App.Support.Common.Protos.Common;
using App.Support.Common.Protos.Promotion;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Service.API.Promotion.Repositories.DiscountCampaign;
using Service.API.Promotion.Repositories.DiscountCode;

namespace Service.API.Promotion.Services.gRPC
{
    public class PromotionGrpcService : PromotionGrpc.PromotionGrpcBase
    {
        private readonly DiscountCampaignRepository _discountCampaignRepository;
        private readonly DiscountCodeRepository _discountCodeRepository;
        private readonly ILogger<PromotionGrpcService> _logger;

        public PromotionGrpcService(ILogger<PromotionGrpcService> logger,
            DiscountCampaignRepository discountCampaignRepository, DiscountCodeRepository discountCodeRepository)
        {
            _discountCampaignRepository = discountCampaignRepository;
            _discountCodeRepository = discountCodeRepository;
            _logger = logger;
        }

        public override async Task<ReturnSingleDiscountCampaign> GetDiscountDetail(
            GetDiscountCampaignDetailRequest request, ServerCallContext context)
        {
            var discountCode = request.DiscountCode;

            var discountCodeObj = await _discountCodeRepository.GetDiscountCodeByCode(discountCode);

            var discountCampaignId = discountCodeObj.DiscountCampaignId;

            var discountCampaignObj = await _discountCampaignRepository.GetById(discountCampaignId);

            var discountCampaignDto = discountCampaignObj.GenerateGrpcDtoFromProduct();

            var returnSingleDiscountCampaign = new ReturnSingleDiscountCampaign
            {
                Status = GrpcStatus.Success,
                DiscountCampaign = discountCampaignDto
            };

            return returnSingleDiscountCampaign;
        }
    }
}