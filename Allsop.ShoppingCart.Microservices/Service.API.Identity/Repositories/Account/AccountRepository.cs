using System.Collections.Generic;
using System.Linq;
using App.Support.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Service.API.Identity.Repositories.Account;

namespace Service.API.Identity.Infrastructure
{
    public class AccountRepository: IAccountRepository
    {
        private AppIdentityDbContext _context;
        
        public AccountRepository(AppIdentityDbContext context)
        {
            this._context = context;
        }
        
        public void Dispose()
        {
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Users.ToList();
        }

        public Account GetAccountById(int studentId)
        {
            throw new System.NotImplementedException();
        }

        public void InsertAccount(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAccount(int accountId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAccount(Account account)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}