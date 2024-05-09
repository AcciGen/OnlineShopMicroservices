using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace User.Application.Abstractions
{
    public interface IUserDbContext
    {
        public DbSet<UserInfo> Users { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
