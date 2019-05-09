using RabbitMQ.Client;
using System;

namespace Overload.EventBus.RabbitMQ
{
    public interface IEventBusRabbitMQConnection : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
