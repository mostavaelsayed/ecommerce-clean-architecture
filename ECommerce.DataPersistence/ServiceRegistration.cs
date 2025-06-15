using ECommerce.DataPersistence.Context;
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

            services.AddDbContext<OrderContext>((_, options) => { 
                options.UseSqlServer(connString);
            });
   

        }
    }
}
