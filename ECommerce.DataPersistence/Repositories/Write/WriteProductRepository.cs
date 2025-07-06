using ECommerce.Application.Repositories.Write;
using ECommerce.DataPersistence.Context;
using ECommerce.Entities;

namespace ECommerce.DataPersistence.Repositories.Write
{
    public class WriteProductRepository : IWriteProductRepository
    {
        private readonly OrderContext context;

        public WriteProductRepository(OrderContext context)
        {
            this.context = context;
        }

        public async Task UpdateAsync(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
