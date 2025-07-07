namespace ECommerceCleanArchitecture.Web.DTOs
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public List<CreateOrderItemRequest> Items { get; set; }
        public int PaymentMethodId { get; set; }
    }

    public class CreateOrderItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
