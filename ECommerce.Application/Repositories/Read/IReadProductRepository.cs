using ECommerce.Entities;

namespace ECommerce.Application.Repositories.Read
{
    public interface IReadProductRepository
    {
        Task<Product> GetByIdAsync(int id);
    }
}
