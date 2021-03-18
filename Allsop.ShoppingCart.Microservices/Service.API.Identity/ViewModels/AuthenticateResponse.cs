using App.Support.Common.Models;
using App.Support.Common.Models.IdentityService;

namespace Service.API.Identity.ViewModels
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Account user, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Token = token;
        }
    }
}