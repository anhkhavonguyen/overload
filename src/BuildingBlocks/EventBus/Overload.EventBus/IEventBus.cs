using System.Threading.Tasks;

namespace Overload.EventBus
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent @event)
           where TEvent : IntegrationEvent;

        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;
    }
}
