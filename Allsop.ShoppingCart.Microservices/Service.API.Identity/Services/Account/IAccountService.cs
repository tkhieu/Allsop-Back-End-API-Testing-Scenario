using System.Threading.Tasks;
using Service.API.Identity.ViewModels;

namespace Service.API.Identity.Services.Account
{
    public interface IAccountService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequestViewModel model);
    }
}