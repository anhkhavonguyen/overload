using MediatR;
using Overload.EventBus;
using Overload.Payment.Infrastructure.Events;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Overload.Payment.Application.TransactionPayments.Queries.GetAllTransactionPayments
{
    public class GetAllTransactionPaymentQueryHandler : IRequestHandler<GetAllTransactionPaymentQuery, Unit>
    {
        private readonly IEventBus _eventBus;

        public GetAllTransactionPaymentQueryHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(GetAllTransactionPaymentQuery request, CancellationToken cancellationToken)
        {
            var result = new List<string>();
            result.Add("test");
            var @event = new PaymentExecutedEvent();
            await _eventBus.PublishAsync(@event);
            return Unit.Value;
        }
    }
}
