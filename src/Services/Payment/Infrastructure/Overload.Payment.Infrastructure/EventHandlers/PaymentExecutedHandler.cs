using Overload.EventBus;
using Overload.Payment.Infrastructure.Events;
using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.EventHandlers
{
    public class PaymentExecutedHandler : IIntegrationEventHandler<PaymentExecutedEvent>
    {
        public PaymentExecutedHandler()
        {

        }

        public Task Handle(PaymentExecutedEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
