using ECommerce.Application.Repositories;
using ECommerce.DataPersistence.Context;
using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataPersistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext context;

        public OrderRepository(OrderContext context)
        {
            this.context = context;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            var orderModel = new Order(order.Name);
            await context.Orders.AddAsync(orderModel);
            return orderModel;
        }
    }
}
