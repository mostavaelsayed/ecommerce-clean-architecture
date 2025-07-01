using ECommerce.Application.Repositories.Read;
using ECommerce.DataPersistence.Context;
using ECommerce.Entities;

namespace ECommerce.DataPersistence.Repositories
{
    public class ReadProductRepository : IReadProductRepository
    {
        private readonly OrderContext context;

        public ReadProductRepository(OrderContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }
    }
}
