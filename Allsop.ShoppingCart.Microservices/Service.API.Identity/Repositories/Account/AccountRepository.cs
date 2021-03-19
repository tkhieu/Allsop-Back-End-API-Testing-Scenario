using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Support.Common.Models;
using App.Support.Common.Models.IdentityService;
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

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _context.Users.ToListAsync();
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