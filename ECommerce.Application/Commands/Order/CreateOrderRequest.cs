namespace ECommerce.Application.Commands.Order
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public List<CreateOrderItemRequest> Items { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class CreateOrderItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
