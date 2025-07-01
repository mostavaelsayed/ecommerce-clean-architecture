using ECommerce.Application.Services.Order.CreateOrder;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    public static class ServicesRegistration
    {

        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderService, CreateOrderService>();
        }
    }
}
