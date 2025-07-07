using ECommerce.Application.Util;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class ServicesRegistration
    {

        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDateTimeService, DateTimeService>();
        }
    }
}
