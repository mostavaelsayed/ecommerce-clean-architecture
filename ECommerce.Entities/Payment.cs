namespace ECommerce.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaidAt { get; set; }
        public string PaymentMethod { get; set; }
    }
}
