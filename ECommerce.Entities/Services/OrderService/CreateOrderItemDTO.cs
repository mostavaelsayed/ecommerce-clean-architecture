using ECommerce.Entities.Aggregates.ProductAggregate;

namespace ECommerce.Entities.Services.OrderService
{
    public class CreateOrderItemDTO
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
