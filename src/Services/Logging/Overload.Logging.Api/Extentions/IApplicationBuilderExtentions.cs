using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Overload.EventBus;


namespace Overload.Payment.Logging.Extentions
{
    public static class IApplicationBuilderExtentions
    {
        public static void ConfigureEventBus(this IApplicationBuilder app, IHostingEnvironment env)
        {
          
        }
    }
}
