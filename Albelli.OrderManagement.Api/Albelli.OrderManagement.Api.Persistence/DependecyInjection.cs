using Albelli.OrderManagement.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Albelli.OrderManagement.Api.Persistence
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IOrdersDbContext>(provider =>
                provider.GetService<OrdersDbContext>()
            );

            return services;
        }
    }
}
