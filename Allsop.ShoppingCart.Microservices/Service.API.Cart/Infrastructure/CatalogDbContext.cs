using Microsoft.EntityFrameworkCore;

namespace Service.API.Cart.Infrastructure
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options)
            : base(options)
        {
        }

        public DbSet<App.Support.Common.Models.Cart> Carts { get; set; }
        public DbSet<App.Support.Common.Models.CartItem> CartItems { get; set; }
    }
}