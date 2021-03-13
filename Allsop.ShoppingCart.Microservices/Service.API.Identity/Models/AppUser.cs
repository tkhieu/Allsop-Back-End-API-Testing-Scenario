namespace Service.API.Identity.Models
{
    public class AppUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string NormalizeUsername { get; set; }
        public string Email { get; set; }
        public string NormalizeEmail { get; set; }
        public string PasswordHash { get; set; }
        public string EmailConfirmed { get; set; }
    }
}