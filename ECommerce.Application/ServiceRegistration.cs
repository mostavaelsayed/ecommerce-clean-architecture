using ECommerce.Application.Services.Order.CreateOrder;
using ECommerce.Entities.Services.OrderService;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    public static class ServicesRegistration
    {

        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderApplicationService, CreateOrderApplicationService>();
        }

        public static void RegisterDomainService(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderService, CreateOrderService>();
        }
    }
}
