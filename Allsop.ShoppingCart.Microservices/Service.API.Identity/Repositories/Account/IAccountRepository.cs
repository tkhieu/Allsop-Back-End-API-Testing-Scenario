using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.API.Identity.Repositories.Account
{
    public interface IAccountRepository: IDisposable
    {
        Task<IEnumerable<App.Support.Common.Models.IdentityService.Account>> GetAccounts();
        App.Support.Common.Models.IdentityService.Account GetAccountById(int studentId);
        void InsertAccount(App.Support.Common.Models.IdentityService.Account account);
        void DeleteAccount(int accountId);
        void UpdateAccount(App.Support.Common.Models.IdentityService.Account account);
        void Save();
    }
}