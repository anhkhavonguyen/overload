using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Payment.Cash
{
    public class CashPaymentExecutor
    {
        public CashPaymentExecutor()
        {

        }

        public Task Execute()
        {
            return Task.CompletedTask;
        }
    }
}
