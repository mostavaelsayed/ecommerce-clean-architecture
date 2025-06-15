namespace ECommerce.Application.Services.Order.CreateOrder
{
    public interface ICreateOrderService
    {
        Task<bool> CreateOrderAsync(string orderName);
    }
}
