using System;
using RabbitMQ.Client;
using Microsoft.Extensions.Logging;
using Polly.Retry;
using System.Net.Sockets;
using RabbitMQ.Client.Exceptions;
using Polly;

namespace Overload.EventBus.RabbitMQ
{
    public class EventBusRabbitMQConnection : IEventBusRabbitMQConnection
    {
        private readonly ILogger<EventBusRabbitMQConnection> _logger;
        private readonly IConnectionFactory _connectionFactory;
        private readonly int _retryCount;
        IConnection _connection;
        bool _disposed;

        object lock_object = new object();

        public EventBusRabbitMQConnection(ILogger<EventBusRabbitMQConnection> logger, IConnectionFactory connectionFactory,int retryCount = 5)
        {
            _logger = logger;
            _connectionFactory = connectionFactory;
            _retryCount = retryCount;
        }

        public bool IsConnected => _connection != null && _connection.IsOpen && !_disposed;

        /// <summary>
        /// Create and return a fresh channel, session, and model.
        /// </summary>
        public IModel CreateModel()
        {
            if(!IsConnected)
            {
                throw new Exception("No Connection");
            }

            return _connection.CreateModel();
        }
        
        public bool TryConnect()
        {
            lock (lock_object)
            {
                var policy = RetryPolicy.Handle<SocketException>()
                    .Or<BrokerUnreachableException>()
                    .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                        _logger.LogWarning(ex.ToString());
                    }
                );

                policy.Execute(() =>
                {
                    _connection = _connectionFactory.CreateConnection();
                });

                if (IsConnected)
                {
                    _logger.LogInformation($"RabbitMQ persistent connection acquired a connection {_connection.Endpoint.HostName} and is subscribed to failure events");
                    return true;
                }
                else
                {
                    _logger.LogCritical("FATAL ERROR: RabbitMQ connections could not be created and opened");
                    return false;
                }
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            try
            {
                _connection.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.ToString());
            }
        }
    }
}
