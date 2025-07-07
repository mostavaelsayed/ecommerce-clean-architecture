using ECommerce.Entities.Aggregates.OrderAggregate;

namespace ECommerce.Application.Repositories.Write
{
    public interface IWriteOrderRepository
    {
        Task<Order> AddAsync(Order order);
    }
}
