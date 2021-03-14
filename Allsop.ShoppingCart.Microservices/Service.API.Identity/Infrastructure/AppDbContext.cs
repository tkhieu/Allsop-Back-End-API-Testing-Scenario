using App.Support.Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Service.API.Identity.Infrastructure
{
    public class AppDbContext: IdentityDbContext<Account>
    {
        
    }
}