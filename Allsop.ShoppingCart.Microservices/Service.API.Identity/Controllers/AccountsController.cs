using System;
using System.Threading.Tasks;
using App.Support.Common.Models.IdentityService;
using App.Support.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.API.Identity.Services.Account;
using Service.API.Identity.ViewModels;

namespace Service.API.Identity.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountsController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly IAccountService _accountService;


        public AccountsController(UserManager<Account> userManager, AccountService accountService)
        {
            this._userManager = userManager;
            this._accountService = accountService;
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
                    Data = { }
                };
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                return new ResultViewModel()
                {
                    Status = Status.Error,
                    Message = "User already exists"
                };
            }

            user = new Account()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
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
                    Message = "Invalid Data"
                };
            }

            var response = await _accountService.Authenticate(model);

            if (response != null)
            {
                return new ResultViewModel()
                {
                    Status = Status.Success,
                    Message = "Authenticate success",
                    Data = response
                };
            }

            return new ResultViewModel()
            {
                Status = Status.Error,
                Message = "Authenticate Error: Wrong email or password",
            };
        }
    }
}