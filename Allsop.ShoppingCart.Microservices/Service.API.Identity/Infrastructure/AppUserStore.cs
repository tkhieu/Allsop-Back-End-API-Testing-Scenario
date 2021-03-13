using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Service.API.Identity.Models;

namespace Service.API.Identity.Infrastructure
{
    public class AppUserStore: IUserStore<AppUser>, IUserPasswordStore<AppUser>, IUserEmailStore<AppUser>
    {
        public void Dispose()
        {
        }

        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            user.Username = userName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizeUsername);
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizeUsername = normalizedName.ToLower();
            return Task.CompletedTask;
        }

        public Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
        {
            UserRepository.Users.Add(new AppUser()
            {
                Id = user.Id,
                Email = user.Email,
                NormalizeUsername = user.NormalizeUsername,
                PasswordHash = user.PasswordHash,
                Username = user.Username
            });
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            var appUser = UserRepository.Users.FirstOrDefault(u => u.Id == user.Id);
 
            if (appUser != null)
            {
                appUser.NormalizeUsername = user.NormalizeUsername;
                appUser.Username = user.Username;
                appUser.NormalizeEmail = user.NormalizeUsername;
                appUser.Email = user.Email;
                appUser.PasswordHash = user.PasswordHash;
                appUser.EmailConfirmed = user.EmailConfirmed;
            }
 
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            var appUser = UserRepository.Users.FirstOrDefault(u => u.Id == user.Id);
            if (appUser != null)
            {
                UserRepository.Users.Remove(appUser);
            }
            return Task.FromResult(IdentityResult.Success);
        }
        
        public Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(UserRepository.Users.FirstOrDefault(u => u.Id == userId));
        }

        public Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.FromResult(UserRepository.Users.FirstOrDefault(u => u.NormalizeUsername == normalizedUserName));
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetEmailAsync(AppUser user, string email, CancellationToken cancellationToken)
        {
            var appUser = UserRepository.Users.FirstOrDefault(u => u.Id == user.Id);
            if (appUser != null)
            {
                appUser.Email = email;
            }
            return Task.CompletedTask;
        }

        public Task<string> GetEmailAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult<string>(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(AppUser user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.FromResult(UserRepository.Users.FirstOrDefault(u => u.Email == normalizedEmail));
        }

        public Task<string> GetNormalizedEmailAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult<string>(user.NormalizeEmail);
        }

        public Task SetNormalizedEmailAsync(AppUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizeEmail = normalizedEmail.ToLower();
            return Task.CompletedTask;
        }
    }
}