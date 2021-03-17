using System.Linq;
using App.Support.Common;
using App.Support.Common.Shared;
using Microsoft.Extensions.Options;
using Service.API.Identity.Infrastructure;
using Service.API.Identity.ViewModels;

namespace Service.API.Identity.Services.Account
{
    public class AccountService: IAccountService
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly AccountRepository _accountRepository;

        public AccountService(IOptions<AppSettings> appSettings, AccountRepository accountRepository)
        {
            this._appSettings = appSettings;
            this._accountRepository = accountRepository;
        }
        
        public AuthenticateResponse Authenticate(AuthenticateRequestViewModel model)
        {

            var account = _accountRepository.GetAccounts().FirstOrDefault(a => a.NormalizedEmail == model.Email.ToUpper());

            var jwtHelper = new JwtHelper();
            var token = jwtHelper.generateJwtToken(account, _appSettings.Value);
            
            if (account != null)
            {
                return new AuthenticateResponse(account, token);
            }

            return null;
        }
    }
}