using Microsoft.EntityFrameworkCore;
using Product.API.Models;

namespace Product.API.Persistance
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) :
            base(options)
        {
            Database.Migrate();
        }

        public DbSet<ProductInfo> Products { get; set; }
    }
}
