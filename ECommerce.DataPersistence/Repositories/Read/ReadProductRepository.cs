using ECommerce.Application.Repositories.Read;
using ECommerce.DataPersistence.Context;
using ECommerce.Entities;
using ECommerce.Entities.Aggregates.ProductAggregate;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataPersistence.Repositories
{
    public class ReadProductRepository : IReadProductRepository
    {
        private readonly OrderContext context;

        public ReadProductRepository(OrderContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetAllByIdAsync(List<int> ids)
        {
            return await context.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
        }
    }
}
