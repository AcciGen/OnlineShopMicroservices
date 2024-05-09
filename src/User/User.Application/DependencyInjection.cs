using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace User.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
