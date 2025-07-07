using ECommerce.Application.Commands.Order;
using ECommerce.Application.Util;

namespace ECommerce.Application.Services.Order.CreateOrder
{
    public interface ICreateOrderApplicationService
    {
        public Task<ApplicationResult> CreateOrderAsync(CreateOrderRequestDTO request);
    }
}
