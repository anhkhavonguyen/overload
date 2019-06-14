namespace Overload.Payment.Infrastructure.Payment
{
    public abstract class BasePayment
    {
        public BasePayment()
        {
        }

        public abstract void Execute(dynamic TEvent);
    }
}
