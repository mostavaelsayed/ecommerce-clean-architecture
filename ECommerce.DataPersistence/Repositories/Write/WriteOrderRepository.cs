using ECommerce.Application.Repositories.Write;
using ECommerce.DataPersistence.Context;
using ECommerce.Entities;
using ECommerce.Entities.Aggregates.OrderAggregate;

namespace ECommerce.DataPersistence.Repositories.Write
{
    public class WriteOrderRepository : IWriteOrderRepository
    {
        private readonly OrderContext context;

        public WriteOrderRepository(OrderContext context)
        {
            this.context = context;
        }

        public async Task<Order> AddAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            return order;
        }
    }
}
