using ECommerce.Application.Commands.Order;

namespace ECommerce.Application.Services.Order.CreateOrder
{
    public interface ICreateOrderService
    {
        public Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request);
    }
}
