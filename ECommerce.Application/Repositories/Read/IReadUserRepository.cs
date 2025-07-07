using ECommerce.Entities;
using ECommerce.Entities.Aggregates.UserAggregate;

namespace ECommerce.Application.Repositories.Read
{
    public interface IReadUserRepository
    {
        Task<User> GetByIdAsync(int id);
    }
}
