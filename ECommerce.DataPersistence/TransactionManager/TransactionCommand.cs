using ECommerce.Application.TransactionManager;
using ECommerce.DataPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataPersistence.TransactionManager
{
    public class TransactionCommand : ITransactionCommand
    {
        private readonly DbContext _dbContext;

        public TransactionCommand(OrderContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task ExecuteAsync(Func<Task> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    await action();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    //Log.Error(ex, "Error while executing the db transaction, rollback has been done.");
                    throw;
                }
            });
        }
    }
}
