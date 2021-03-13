using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.API.Identity.Models;
using Service.API.Identity.ViewModels;

namespace Service.API.Identity.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
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

            user = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                Username = model.Username,
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
    }
}