using ECommerce.Entities.Constants;
using ECommerce.Entities.Services.OrderService;

namespace ECommerce.Entities.Aggregates.OrderAggregate
{
    public class Order
    {
        public Order()
        {
            
        }
        private Order(int userId, List<OrderItem> items, PaymentMethodEnum paymentMethod, DateTime now)
        {
            UserId = userId;
            Items = items;
            TotalAmount = Items.Sum(i => i.Quantity * i.UnitPrice);
            OrderDate = now;
            Status = OrderStatusEnum.Pending;
            Payment = Payment.Create(TotalAmount, now, paymentMethod);
        }
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int PaymentId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatusEnum Status { get; private set; }
        public decimal TotalAmount { get; private set; }

        public List<OrderItem> Items { get; private set; } = new();
        public Payment Payment { get; private set; }


        public static Order Create(int userId, List<CreateOrderItemDTO> items, PaymentMethodEnum paymentMethod, DateTime now)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var item in items)
            {
                item.Product.ReduceQuantity(item.Quantity);
                var orderItem = OrderItem.Create(item.Product.Id, item.Product.Name, item.Quantity, item.Product.Price);
                orderItems.Add(orderItem);
            }
            return new Order(userId, orderItems, paymentMethod, now);
        }
    }
}