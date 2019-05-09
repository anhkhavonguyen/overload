using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Overload.EventBus;
using Overload.EventBus.RabbitMQ;
using Overload.Payment.Infrastructure.EventHandlers;
using RabbitMQ.Client;

namespace Overload.Payment.Api.Extentions
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBusRabbitMQConnection, EventBusRabbitMQConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = configuration["RabbitMqConfig:EventBusConnection"]
                };

                if (!string.IsNullOrEmpty(configuration["RabbitMqConfig:EventBusUserName"]))
                {
                    factory.UserName = configuration["RabbitMqConfig:EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(configuration["RabbitMqConfig:EventBusPassword"]))
                {
                    factory.Password = configuration["RabbitMqConfig:EventBusPassword"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["RabbitMqConfig:EventBusRetryCount"]))
                {
                    retryCount = int.Parse(configuration["RabbitMqConfig:EventBusRetryCount"]);
                }

                return new EventBusRabbitMQConnection(logger, factory, retryCount);
            });


            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var subscriptionClientName = configuration["SubscriptionClientName"];

                var rabbitMQPersistentConnection = sp.GetRequiredService<IEventBusRabbitMQConnection>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["RabbitMqConfig:EventBusRetryCount"]))
                {
                    retryCount = int.Parse(configuration["RabbitMqConfig:EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, subscriptionClientName, retryCount);
            });


            services.AddTransient<PaymentExecutedHandler>();

            return services;
        }
    }
}
