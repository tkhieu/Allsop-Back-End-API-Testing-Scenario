using App.Support.Common.Models.CartService;
using Microsoft.EntityFrameworkCore;

namespace Service.API.Cart.Infrastructure
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options)
            : base(options)
        {
        }

        public DbSet<App.Support.Common.Models.CartService.Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}