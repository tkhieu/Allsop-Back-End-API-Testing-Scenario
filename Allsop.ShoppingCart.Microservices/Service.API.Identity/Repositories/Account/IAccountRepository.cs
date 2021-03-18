using System;
using System.Collections.Generic;

namespace Service.API.Identity.Repositories.Account
{
    public interface IAccountRepository: IDisposable
    {
        IEnumerable<App.Support.Common.Models.IdentityService.Account> GetAccounts();
        App.Support.Common.Models.IdentityService.Account GetAccountById(int studentId);
        void InsertAccount(App.Support.Common.Models.IdentityService.Account account);
        void DeleteAccount(int accountId);
        void UpdateAccount(App.Support.Common.Models.IdentityService.Account account);
        void Save();
    }
}