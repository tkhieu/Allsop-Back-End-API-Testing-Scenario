using System.Linq;
using System.Threading.Tasks;
using App.Support.Common;
using App.Support.Common.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.API.Identity.Infrastructure;
using Service.API.Identity.ViewModels;

namespace Service.API.Identity.Services.Account
{
    public class AccountService: IAccountService
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly AccountRepository _accountRepository;
        private readonly UserManager<App.Support.Common.Models.IdentityService.Account> _userManager;

        public AccountService(IOptions<AppSettings> appSettings, AccountRepository accountRepository, UserManager<App.Support.Common.Models.IdentityService.Account> userManager)
        {
            this._appSettings = appSettings;
            this._accountRepository = accountRepository;
            this._userManager = userManager;
        }
        
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequestViewModel model)
        {

            var accounts = await _accountRepository.GetAccounts();
            var account = accounts.FirstOrDefault(a => a.NormalizedEmail == model.Email.ToUpper());

            if (account == null) return null;
            
            var passwordVerificationResult = _userManager.PasswordHasher.VerifyHashedPassword(account, account.PasswordHash, model.Password);

            if (passwordVerificationResult != PasswordVerificationResult.Success) return null;
            
            var jwtHelper = new JwtHelper();
            var token = jwtHelper.generateJwtToken(account, _appSettings.Value);
            return new AuthenticateResponse(account, token);
        }
    }
}