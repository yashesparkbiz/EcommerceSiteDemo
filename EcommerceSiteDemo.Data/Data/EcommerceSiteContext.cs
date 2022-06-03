using Microsoft.EntityFrameworkCore;

namespace EcommerceSiteDemo.Data.Data
{
    public class EcommerceSiteContext: DbContext
    {
        public EcommerceSiteContext(DbContextOptions options): base(options) {}

        public DbSet< User > User { get; set; } 

        public DbSet<Address> Address { get; set; }

        public DbSet<Discount> Discount { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order_Details> Order_Details { get; set; }

        public DbSet<Product_wishlist> Product_wishlist { get; set; }

        public DbSet<Product_category> Product_category { get; set; }

        public DbSet<Product_subcategory> Product_subcategory { get; set; }

        public DbSet<Product_cart> Product_cart { get; set; }
    }
}
