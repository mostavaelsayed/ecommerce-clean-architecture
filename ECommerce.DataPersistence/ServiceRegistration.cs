using ECommerce.Application.Repositories.Read;
using ECommerce.Application.Repositories.Write;
using ECommerce.Application.TransactionManager;
using ECommerce.DataPersistence.Context;
using ECommerce.DataPersistence.Repositories;
using ECommerce.DataPersistence.Repositories.Write;
using ECommerce.DataPersistence.TransactionManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.DataPersistence
{
    public static class ServicesRegistration
    {
        public static void RegisterOrdersContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connString = configuration.GetConnectionString("DefaultConnection")!;

            services.AddDbContext<OrderContext>((_, options) =>
            {
                options.UseSqlServer(connString);
            });

        }

        public static void RegisterRepositories(this IServiceCollection services)
        {

            services.AddScoped<ITransactionCommand, TransactionCommand>();

            services.AddScoped<IReadUserRepository, ReadUserRepository>();
            services.AddScoped<IReadProductRepository, ReadProductRepository>();

            services.AddScoped<IWriteOrderRepository, WriteOrderRepository>();
            services.AddScoped<IWriteProductRepository, WriteProductRepository>();
        }
    }
}
