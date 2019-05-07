using Overload.EventBus.Interface;
using System;
using System.Threading.Tasks;

namespace Overload.EventBus.RabbitMQ
{
    public class MasstransitEventBus : IEventBus
    {
        public MasstransitEventBus()
        {

        }

        public Task AddSubscription<T, THandler>()
            where T : class
            where THandler : class
        {
            throw new NotImplementedException();
        }

        public Task Publish<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
