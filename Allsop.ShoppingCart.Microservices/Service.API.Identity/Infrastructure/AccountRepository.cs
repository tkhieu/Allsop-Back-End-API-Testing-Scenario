using System.Collections.Generic;
using App.Support.Common.Models;
using Microsoft.AspNetCore.Identity;

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