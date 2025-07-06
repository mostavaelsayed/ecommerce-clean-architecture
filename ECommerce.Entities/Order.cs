namespace ECommerce.Entities
{
    public class Order
    {

        public Order()
        {
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
