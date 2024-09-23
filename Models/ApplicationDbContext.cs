using Microsoft.EntityFrameworkCore;

namespace jeweller_app.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CartItemModel> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }

        // DbSet for Orders
        public DbSet<Order> Orders { get; set; }
    }
}
