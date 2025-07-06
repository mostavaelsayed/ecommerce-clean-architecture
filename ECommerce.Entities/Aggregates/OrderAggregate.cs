namespace ECommerce.Entities.Aggregates
{
    public class OrderAggregate
    {
        public OrderAggregate()
        {

        }
        private const int MaxOrderItems = 10;
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;
        public string Status { get; private set; } = "Pending";
        public decimal TotalAmount { get; private set; }

        public List<OrderItem> Items { get; private set; } = new();
        public Payment Payment { get; private set; }

        private readonly HashSet<int> _productIds = new();

        public void SetUser(int userId) => UserId = userId;
        public void AddItem(int productId, string productName, int quantity, decimal price)
        {
            if (_productIds.Contains(productId))
                throw new InvalidOperationException("Duplicate product in order.");

            if (Items.Count >= MaxOrderItems)
                throw new InvalidOperationException("Maximum order item limit exceeded.");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            Items.Add(new OrderItem
            {
                ProductId = productId,
                ProductName = productName,
                Quantity = quantity,
                UnitPrice = price
            });

            _productIds.Add(productId);
        }

        public void CalculateTotal()
        {
            if (!Items.Any())
                throw new InvalidOperationException("Order must contain at least one item.");

            TotalAmount = Items.Sum(i => i.Quantity * i.UnitPrice);
        }

        public void SetPayment(decimal amount, string method)
        {
            Payment = new Payment
            {
                PaidAmount = amount,
                PaidAt = DateTime.UtcNow,
                PaymentMethod = method
            };
        }
    }
}