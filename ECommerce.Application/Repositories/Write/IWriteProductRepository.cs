using ECommerce.Entities;

namespace ECommerce.Application.Repositories.Write
{
    public interface IWriteProductRepository
    {
        Task UpdateAsync(Product product);
    }
}
