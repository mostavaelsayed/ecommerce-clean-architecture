using ECommerce.Entities.Aggregates.OrderAggregate;
using ECommerce.Entities.Aggregates.UserAggregate;
using ECommerce.Entities.Constants;

namespace ECommerce.Entities.Services.OrderService
{
    public interface ICreateOrderService
    {
        Order CreateOrder(User user, List<CreateOrderItemDTO> items, PaymentMethodEnum paymentMethod, DateTime now);
    }
}