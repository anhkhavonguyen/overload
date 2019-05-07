using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Overload.EventBus.Interface
{
    public interface IEventBus
    {
        Task AddSubscription<T, THandler>()
            where T : class
            where THandler : class;

        Task Publish<T>() where T : class;
    }
}
