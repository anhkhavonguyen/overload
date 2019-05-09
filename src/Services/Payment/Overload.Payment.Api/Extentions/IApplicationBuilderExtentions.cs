using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Overload.EventBus;
using Overload.Payment.Infrastructure.EventHandlers;
using Overload.Payment.Infrastructure.Events;

namespace Overload.Payment.Api.Extentions
{
    public static class IApplicationBuilderExtentions
    {
        public static void ConfigureEventBus(this IApplicationBuilder app, IHostingEnvironment env)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<PaymentExecutedEvent, PaymentExecutedHandler>();
        }
    }
}
