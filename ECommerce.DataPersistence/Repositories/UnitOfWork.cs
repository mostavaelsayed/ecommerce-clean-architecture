using ECommerce.Application.Repositories;
using ECommerce.DataPersistence.Context;

namespace ECommerce.DataPersistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderContext dbContext;

        public UnitOfWork(OrderContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
