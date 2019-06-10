namespace Overload.Payment.Infrastructure.Payment
{
    //Abstract Factory
    public abstract class BasePayment
    {
        public BasePayment()
        {
        }

        public abstract void Execute(dynamic TEvent);
    }
}
