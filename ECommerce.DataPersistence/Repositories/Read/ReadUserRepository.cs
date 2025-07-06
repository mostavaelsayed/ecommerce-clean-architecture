using ECommerce.Application.Repositories.Read;
using ECommerce.DataPersistence.Context;
using ECommerce.Entities;

namespace ECommerce.DataPersistence.Repositories
{
    public class ReadUserRepository : IReadUserRepository
    {
        private readonly OrderContext context;

        public ReadUserRepository(OrderContext context)
        {
            this.context = context;
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }
    }
}
