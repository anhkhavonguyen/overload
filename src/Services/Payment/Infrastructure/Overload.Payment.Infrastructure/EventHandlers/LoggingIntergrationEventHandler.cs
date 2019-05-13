using Overload.EventBus;
using Overload.Payment.Infrastructure.Events;
using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.EventHandlers
{
    public class LoggingIntergrationEventHandler : IIntegrationEventHandler<LoggingIntergrationEvent>
    {
        public LoggingIntergrationEventHandler()
        {
                
        }

        public Task Handle(LoggingIntergrationEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
