using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Abstractions;
using User.Infrastructure.Persistance;

namespace User.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IUserDbContext, UserDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            });

            return services;
        }
    }
}
