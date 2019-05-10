using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Overload.EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        const string BROKER_NAME = "overload_event_bus";

        private readonly IEventBusRabbitMQConnection _eventBusRabbitMQConnection;
        private readonly ILogger<EventBusRabbitMQ> _logger;

        private IModel _consumerChannel;
        private string _queueName;
        private readonly int _retryCount;
        private readonly List<Type> _eventTypes;
        private readonly Dictionary<string, List<Type>> _handlers;

        public EventBusRabbitMQ(IEventBusRabbitMQConnection eventBusRabbitMQConnection, ILogger<EventBusRabbitMQ> logger, string queueName = null, int retryCount = 5)
        {
            _eventBusRabbitMQConnection = eventBusRabbitMQConnection;
            _logger = logger;
            _retryCount = retryCount;
            _queueName = queueName;
            _consumerChannel = CreateConsumerChannel();
            _eventTypes = new List<Type>();
            _handlers = new Dictionary<string, List<Type>>();
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IntegrationEvent
        {
            if (!_eventBusRabbitMQConnection.IsConnected)
            {
                _eventBusRabbitMQConnection.TryConnect();
            }

            var policy = RetryPolicy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    _logger.LogWarning(ex.ToString());
                });

            using (var channel = _eventBusRabbitMQConnection.CreateModel())
            {
                var eventName = @event.GetType().Name;

                channel.ExchangeDeclare(exchange: BROKER_NAME,type: "direct");

                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                policy.Execute(() =>
                {
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2; // persistent

                    channel.BasicPublish(exchange: BROKER_NAME,
                                     routingKey: eventName,
                                     mandatory: true,
                                     basicProperties: properties,
                                     body: body);
                });
            }
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = typeof(T).Name;
            _eventTypes.Add(typeof(T));
            _handlers.Add(eventName, new List<Type>());
            _handlers[eventName].Add(typeof(TH));
            DoInternalSubscription(eventName);
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void DoInternalSubscription(string eventName)
        {
            if (!_eventBusRabbitMQConnection.IsConnected)
            {
                _eventBusRabbitMQConnection.TryConnect();
            }

            using (var channel = _eventBusRabbitMQConnection.CreateModel())
            {
                channel.QueueBind(queue: _queueName,
                                  exchange: BROKER_NAME,
                                  routingKey: eventName);
            }

        }

        private IModel CreateConsumerChannel()
        {
            if (!_eventBusRabbitMQConnection.IsConnected)
            {
                _eventBusRabbitMQConnection.TryConnect();
            }

            var channel = _eventBusRabbitMQConnection.CreateModel();

            channel.ExchangeDeclare(exchange: BROKER_NAME,type: "direct");

            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var eventName = ea.RoutingKey;
                var message = Encoding.UTF8.GetString(ea.Body);

                // await ProcessEvent(eventName, message);

                channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(queue: _queueName,
                                 autoAck: false,
                                 consumer: consumer);

            return channel;
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            var eventType = _eventTypes.FirstOrDefault(e=>e.Name == eventName);
            var integrationEvent = JsonConvert.DeserializeObject(message, eventType);
            var handler = _handlers[eventName];
            var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
            await(Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent });
        }
    }
}
