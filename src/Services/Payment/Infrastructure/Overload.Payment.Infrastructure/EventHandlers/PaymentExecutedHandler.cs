using Overload.EventBus;
using Overload.Payment.Infrastructure.Events;
using System;
using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.EventHandlers
{
    public class PaymentExecutedHandler : IIntegrationEventHandler<PaymentExecutedEvent>
    {

        public Task Handle(PaymentExecutedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
