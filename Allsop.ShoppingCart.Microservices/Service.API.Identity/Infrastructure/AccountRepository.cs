using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Service.API.Identity.Models;

namespace Service.API.Identity.Infrastructure
{
    public static class AccountRepository
    {
        public static List<Account> Accounts;

        static AccountRepository()
        {
            Accounts = new List<Account>();
        }
    }
}