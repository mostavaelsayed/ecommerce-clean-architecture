namespace ECommerce.Entities.Aggregates.ProductAggregate
{
    public class Product
    {

        public Product()
        {
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQty { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void ReduceQuantity(int quantity)
        {
            if (StockQty < quantity)
                throw new InvalidOperationException($"Insufficient stock for {Name}.");
            StockQty -= quantity;
        }
    }
}
