using System.Linq;
using Service.API.Identity.Infrastructure;
using Service.API.Identity.ViewModels;

namespace Service.API.Identity.Services.Account
{
    public class AccountService: IAccountService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequestViewModel model)
        {

            var account = UserRepository.Users.FirstOrDefault(a => a.NormalizedEmail == model.Email);
            if (account != null)
            {
                return new AuthenticateResponse(null, "token");
            }

            return null;
        }
    }
}