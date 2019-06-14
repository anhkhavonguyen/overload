using Overload.Payment.Infrastructure.Payment.Cash;
using Overload.Payment.Persistence;
using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Payment
{
    public class CashPayment : BasePayment, ICashPayment
    {
        private CashPaymentExecutor executor;
        public CashPayment()
        {
        }

        public override void Execute(dynamic TEvent)
        {
            if(executor == null)
            {
                executor = new CashPaymentExecutor();
            }

            executor.Execute();
        }

        public Task Process(dynamic TEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}
