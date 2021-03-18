using System.Threading.Tasks;

namespace Service.API.Promotion.Repositories.DiscountCode
{
    public interface IDiscountCodeRepository
    {
        Task<App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode> GetDiscountCodeByCode(string code);
    }
}