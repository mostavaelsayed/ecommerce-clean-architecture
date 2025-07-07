using ECommerce.Entities.Constants;

namespace ECommerce.Entities.Aggregates.OrderAggregate
{
    public class Payment
    {
        public Payment()
        {
            
        }
        public int Id { get; private set; }
        public decimal PaidAmount { get; private set; }
        public DateTime PaidAt { get; private set; }
        public PaymentMethodEnum PaymentMethod { get; private set; }

        public static Payment Create(decimal PaidAmount, DateTime PaidAt, PaymentMethodEnum PaymentMethod)
        {
            return new Payment() { PaidAmount = PaidAmount, PaymentMethod = PaymentMethod, PaidAt = PaidAt };
        }
    }
}
