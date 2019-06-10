using Overload.Payment.Infrastructure.Events;
using Overload.Payment.Infrastructure.Payment;
using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Services.Checkout
{
    //Abstract Factory
    public class PaymentProcessorFactory : IPaymentProcessorFactory
    {
        private readonly ICashPayment _cashPayment;
        private readonly ICreditPayment _creditPayment;
        public PaymentProcessorFactory(ICashPayment cashPayment, ICreditPayment creditPayment)
        {
            _cashPayment = cashPayment;
            _creditPayment = creditPayment;
        }

        public Task Process(string method)
        {
            var tevent = new PaymentCreatedEvent();

            switch (method)
            {
                case "Cash":
                    //BasePayment payment = new CashFactory();
                    //payment.Execute(tevent);

                    _cashPayment.Process(tevent);
                    break;
                case "Credit":
                    //BasePayment payment = new CreditFactory();
                    //payment.Execute(tevent);

                    _creditPayment.Process(tevent);
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
