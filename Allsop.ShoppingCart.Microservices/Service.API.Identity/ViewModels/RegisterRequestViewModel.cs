using System.ComponentModel.DataAnnotations;

namespace Service.API.Identity.ViewModels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}