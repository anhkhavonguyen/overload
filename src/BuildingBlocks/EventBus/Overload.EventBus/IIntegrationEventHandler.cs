using System.Threading.Tasks;

namespace Overload.EventBus
{
    public interface IIntegrationEventHandler<TEvent> where TEvent : IntegrationEvent
    {
        Task Handle(TEvent @event);
    }
}
