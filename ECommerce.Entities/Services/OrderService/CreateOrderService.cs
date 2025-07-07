using ECommerce.Entities.Aggregates.OrderAggregate;
using ECommerce.Entities.Aggregates.ProductAggregate;
using ECommerce.Entities.Aggregates.UserAggregate;
using ECommerce.Entities.Constants;
using System.Transactions;

namespace ECommerce.Entities.Services.OrderService
{
    public class CreateOrderService : ICreateOrderService
    {
        public CreateOrderService() { }
        public Order CreateOrder(User user, List<CreateOrderItemDTO> items, PaymentMethodEnum paymentMethod, DateTime now)
        {
            if (!user.IsActive)
                throw new InvalidOperationException("User is not active.");

            if (!items.Any())
                throw new InvalidOperationException("Order must contain at least one item.");

            if (items.Count >= OrderConstantsHelpers.MaxOrderItems)
                throw new InvalidOperationException("Maximum order item limit exceeded.");

            var order = Order.Create(user.Id, items, paymentMethod, now);
            return order;
        }
    }
}
