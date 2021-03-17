using System;
using System.Threading.Tasks;
using App.Support.Common.Models;
using App.Support.Common.Models.IdentityService;
using App.Support.Common.Shared;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.API.Identity.Infrastructure;
using Service.API.Identity.Services.Account;
using Service.API.Identity.ViewModels;

namespace Service.API.Identity.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountsController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly IAccountService _accountService;
        private readonly IOptions<AppSettings> _configuration;


        public AccountsController(UserManager<Account> userManager, AccountService accountService, IOptions<AppSettings> appSettings)
        {
            this._userManager = userManager;
            this._accountService = accountService;
            this._configuration = appSettings;
        }

        [HttpPost]
        public async Task<ResultViewModel> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultViewModel()
                {
                    Status = Status.Error,
                    Message = "Invalid Data",
                    Data = {}
                };
            }

            IdentityResult result = null;
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return new ResultViewModel()
                {
                    Status = Status.Error,
                    Message = "User already exists",
                    Data = {}
                };
            }

            user = new Account()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email
            };

            result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return new ResultViewModel()
                {
                    Status = Status.Success,
                    Message = "User created",
                    Data = user
                };
            }
            
            return new ResultViewModel()
            {
                Status = Status.Error,
                Message = "User create error",
                Data = result.Errors
            };
        }

        [HttpPost]
        public async Task<ResultViewModel> Authenticate([FromBody] AuthenticateRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultViewModel()
                {
                    Status = Status.Error,
                    Message = "Invalid Data",
                    Data = { }
                };
            }

            var response = _accountService.Authenticate(model);

            return new ResultViewModel()
            {
                Status = Status.Success,
                Message = "Authenticate success",
                Data =  response
            };
        }
    }
}