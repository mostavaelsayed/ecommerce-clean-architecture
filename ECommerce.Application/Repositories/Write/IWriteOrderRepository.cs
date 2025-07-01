using ECommerce.Entities;

namespace ECommerce.Application.Repositories.Write
{
    public interface IWriteOrderRepository
    {
        Task<Order> AddAsync(Order order);
    }
}
