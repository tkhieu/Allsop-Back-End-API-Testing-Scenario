using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Service.API.Identity.Infrastructure
{
    public static class UserRepository
    {
        public static List<IdentityUser> Users;

        static UserRepository()
        {
            Users = new List<IdentityUser>();
        }
    }
}