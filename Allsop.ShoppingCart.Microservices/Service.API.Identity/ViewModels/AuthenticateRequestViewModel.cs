using System.ComponentModel.DataAnnotations;

namespace Service.API.Identity.ViewModels
{
    public class AuthenticateRequestViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}