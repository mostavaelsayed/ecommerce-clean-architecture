using ECommerce.Entities.Constants;

namespace ECommerce.Entities.Aggregates.OrderAggregate
{
    public class OrderItem
    {
        public OrderItem()
        {
        }
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }

        public static OrderItem Create(int productId, string productName, int quantity, decimal price)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            return new OrderItem()
            {
                ProductId = productId,
                Quantity = quantity,
                ProductName = productName,
                UnitPrice = price
            };
        }

    }
}
