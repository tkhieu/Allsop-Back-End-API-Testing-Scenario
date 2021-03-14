using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using App.Support.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Service.API.Identity.Infrastructure
{
    public class AppUserStore : UserStoreBase<Account, string, IdentityUserClaim<string>, IdentityUserLogin<string>
        , IdentityUserToken<string>>
    {
        public AppUserStore(IdentityErrorDescriber describer) : base(describer)
        {
        }

        public override Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken = new CancellationToken())
        {
            AccountRepository.Accounts.Add(new Account()
            {
                Id = user.Id,
                Email = user.Email,
                NormalizedUserName = user.NormalizedUserName,
                PasswordHash = user.PasswordHash,
                UserName = user.UserName
            });
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken = new CancellationToken())
        {
            var appUser = AccountRepository.Accounts.FirstOrDefault(u => u.Id == user.Id);
 
            if (appUser != null)
            {
                appUser.NormalizedUserName = user.NormalizedUserName;
                appUser.UserName = user.UserName;
                appUser.NormalizedEmail = user.NormalizedUserName;
                appUser.Email = user.Email;
                appUser.PasswordHash = user.PasswordHash;
                appUser.EmailConfirmed = user.EmailConfirmed;
            }
 
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken = new CancellationToken())
        {
            var appUser = AccountRepository.Accounts.FirstOrDefault(u => u.Id == user.Id);
            if (appUser != null)
            {
                AccountRepository.Accounts.Remove(appUser);
            }
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<Account> FindByIdAsync(string userId, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(AccountRepository.Accounts.FirstOrDefault(u => u.Id == userId));
        }

        public override Task<Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(AccountRepository.Accounts.FirstOrDefault(u => u.NormalizedUserName == normalizedUserName));
        }

        protected override Task<Account> FindUserAsync(string userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(AccountRepository.Accounts.FirstOrDefault(u => u.Id == userId));
        }

        protected override Task<IdentityUserLogin<string>> FindUserLoginAsync(string userId, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        protected override Task<IdentityUserLogin<string>> FindUserLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IList<Claim>> GetClaimsAsync(Account user, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public override Task AddClaimsAsync(Account user, IEnumerable<Claim> claims,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public override Task ReplaceClaimAsync(Account user, Claim claim, Claim newClaim,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public override Task RemoveClaimsAsync(Account user, IEnumerable<Claim> claims,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public override Task<IList<Account>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        protected override Task<IdentityUserToken<string>> FindTokenAsync(Account user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        protected override Task AddUserTokenAsync(IdentityUserToken<string> token)
        {
            throw new System.NotImplementedException();
        }

        protected override Task RemoveUserTokenAsync(IdentityUserToken<string> token)
        {
            throw new System.NotImplementedException();
        }

        public override IQueryable<Account> Users { get; }

        public override Task AddLoginAsync(Account user, UserLoginInfo login,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public override Task RemoveLoginAsync(Account user, string loginProvider, string providerKey,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public override Task<IList<UserLoginInfo>> GetLoginsAsync(Account user, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public override Task<Account> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(AccountRepository.Accounts.FirstOrDefault(u => u.Email == normalizedEmail));
        }
    }
}