using ECommerce.Application.Repositories.Write;
using ECommerce.DataPersistence.Context;
using ECommerce.Entities;

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
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return order;
        }
    }
}
