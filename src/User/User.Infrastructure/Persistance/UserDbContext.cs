using Microsoft.EntityFrameworkCore;
using User.Application.Abstractions;
using User.Domain.Entities;

namespace User.Infrastructure.Persistance
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) :
            base(options)
        {
            Database.Migrate();
        }

        public DbSet<UserInfo> Users { get; set; }
    }
}
