using Microsoft.EntityFrameworkCore;
using Payment.API.Models;

namespace Payment.API.Persistance
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) :
            base(options)
        {
            Database.Migrate();
        }

        public DbSet<PaymentInfo> Payments { get; set; }
    }
}
