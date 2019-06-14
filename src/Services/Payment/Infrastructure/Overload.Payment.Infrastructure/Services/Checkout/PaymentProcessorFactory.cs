using Overload.Payment.Infrastructure.Events;
using Overload.Payment.Infrastructure.Payment;
using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Services.Checkout
{
    //Abstract Factory
    public class PaymentProcessorFactory : IPaymentProcessorFactory
    {
        public PaymentProcessorFactory()
        {
        }

        public Task Process(string method,decimal amount)
        {
            var tEvent = new PaymentCreatedEvent();
            switch (method)
            {
                case "Cash":
                    BasePayment cashPayment = new CashPayment();
                    cashPayment.Execute(tEvent);
                    break;
                case "Credit":
                    BasePayment creditPayment = new CreditPayment();
                    creditPayment.Execute(tEvent);
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
