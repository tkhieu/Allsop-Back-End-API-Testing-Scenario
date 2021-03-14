using Service.API.Identity.ViewModels;

namespace Service.API.Identity.Services.Account
{
    public interface IAccountService
    {
        AuthenticateResponse Authenticate(AuthenticateRequestViewModel model);
    }
}