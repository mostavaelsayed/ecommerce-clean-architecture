namespace ECommerce.Entities
{
    public class Product
    {
        public Product()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQty { get; set; }
        public DateTime CreatedAt { get; set; }

        public void ReduceQuantity(int quantity)
        {
            if (StockQty < quantity)
                throw new InvalidOperationException($"Insufficient stock for {Name}.");
            StockQty -= quantity;
        }
    }
}
