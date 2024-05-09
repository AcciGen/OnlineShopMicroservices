using Microsoft.EntityFrameworkCore;
using Order.API.Models;

namespace Order.API.Persistance
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) :
            base(options)
        {
            Database.Migrate();
        }

        public DbSet<OrderInfo> Orders { get; set; }
    }
}
