using System.Collections.Generic;
using Service.API.Identity.Models;

namespace Service.API.Identity.Infrastructure
{
    public static class UserRepository
    {
        public static List<AppUser> Users;

        static UserRepository()
        {
            Users = new List<AppUser>();
        }
    }
}