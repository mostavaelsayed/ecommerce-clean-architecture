
using ECommerce.Application.Repositories;

namespace ECommerce.Application.Services.Order.CreateOrder
{
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IOrderRepository orderRepository;

        public CreateOrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrderAsync(string orderName)
        {
            var orderEntity = new Entities.Order(
                orderName
            );

            var order = await orderRepository.CreateOrderAsync(orderEntity);

            return (order != null && order.Id > 0);
        }
    }
}
