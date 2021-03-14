using System;
using System.Collections.Generic;

namespace Service.API.Identity.Repositories.Account
{
    public interface IAccountRepository: IDisposable
    {
        IEnumerable<App.Support.Common.Models.Account> GetAccounts();
        App.Support.Common.Models.Account GetAccountById(int studentId);
        void InsertAccount(App.Support.Common.Models.Account account);
        void DeleteAccount(int accountId);
        void UpdateAccount(App.Support.Common.Models.Account account);
        void Save();
    }
}