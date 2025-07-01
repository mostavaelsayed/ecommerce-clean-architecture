namespace ECommerce.Application.TransactionManager
{
    public interface ITransactionCommand
    {
        Task ExecuteAsync(Func<Task> action);
    }
}
