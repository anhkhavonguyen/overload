using MediatR;
using Overload.EventBus;
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
            return Unit.Value;
        }
    }
}
