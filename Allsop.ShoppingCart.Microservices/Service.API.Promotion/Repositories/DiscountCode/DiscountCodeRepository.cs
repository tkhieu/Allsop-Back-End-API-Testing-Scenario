using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using App.Support.Common;
using Microsoft.EntityFrameworkCore;
using Service.API.Promotion.Infrastructure;

namespace Service.API.Promotion.Repositories.DiscountCode
{
    public class DiscountCodeRepository: IDiscountCodeRepository
    {
        private PromotionDbContext _promotionDbContext;

        public DiscountCodeRepository(PromotionDbContext promotionDbContext)
        {
            _promotionDbContext = promotionDbContext;
        }
        public async Task<App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode> GetDiscountCodeByCode(string code)
        {
            var normalizedCode = DiscountCodeHelper.ReplaceDash(code).Normalize();
            var discountCode =
               await _promotionDbContext.DiscountCodes.FirstOrDefaultAsync(dc => dc.NormalizedCode.Equals(normalizedCode));

            return discountCode;
        }
    }
}