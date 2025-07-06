namespace ECommerce.Entities
{
    public class OrderItem
    {
        public OrderItem()
        {
        }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
