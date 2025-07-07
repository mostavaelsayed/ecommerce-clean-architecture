using ECommerce.Entities.Aggregates.ProductAggregate;

namespace ECommerce.Application.Repositories.Read
{
    public interface IReadProductRepository
    {
        Task<List<Product>> GetAllByIdAsync(List<int> ids);
    }
}
