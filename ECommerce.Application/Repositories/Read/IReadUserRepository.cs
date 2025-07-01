using ECommerce.Entities;

namespace ECommerce.Application.Repositories.Read
{
    public interface IReadUserRepository
    {
        Task<User> GetByIdAsync(int id);
    }
}
