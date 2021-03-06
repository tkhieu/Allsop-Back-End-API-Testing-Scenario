using App.Support.Common.Models;
using App.Support.Common.Models.IdentityService;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Service.API.Identity.Infrastructure
{
    public class AppIdentityDbContext: IdentityDbContext<Account>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }
    }
}