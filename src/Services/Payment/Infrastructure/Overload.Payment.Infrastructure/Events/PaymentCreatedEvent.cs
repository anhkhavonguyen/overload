namespace Overload.Payment.Infrastructure.Events
{
    public class PaymentCreatedEvent
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
    }
}
