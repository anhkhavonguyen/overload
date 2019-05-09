using System;

namespace Overload.EventBus
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
