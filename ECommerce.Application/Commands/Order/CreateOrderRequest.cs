using ECommerce.Entities.Constants;

namespace ECommerce.Application.Commands.Order
{
    public class CreateOrderRequestDTO
    {
        public int UserId { get; set; }
        public List<CreateOrderItemRequestDTO> Items { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
    }

    public class CreateOrderItemRequestDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
