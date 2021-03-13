using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Service.API.Identity.Infrastructure
{
    public class AppUserManager : UserManager<IdentityUser>
    {
        private readonly IConfiguration _configuration;
        
        public AppUserManager(IUserStore<IdentityUser> store, 
                                IOptions<IdentityOptions> optionsAccessor,
                                IPasswordHasher<IdentityUser> passwordHasher, 
                                IEnumerable<IUserValidator<IdentityUser>> userValidators, 
                                IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators, 
                                ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
                                IServiceProvider services, 
                                ILogger<UserManager<IdentityUser>> logger,
                                IConfiguration configuration)
                                : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _configuration = configuration;
        }
    }
}