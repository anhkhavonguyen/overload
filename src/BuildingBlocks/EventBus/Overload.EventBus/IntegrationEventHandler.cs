using System.Threading.Tasks;

namespace Overload.EventBus
{
    public class IntegrationEventHandler<TEvent> : IIntegrationEventHandler<TEvent> where TEvent : IntegrationEvent
    {
        public Task Handle(TEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
