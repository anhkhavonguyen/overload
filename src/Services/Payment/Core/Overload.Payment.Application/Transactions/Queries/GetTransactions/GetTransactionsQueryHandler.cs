using MediatR;
using Overload.EventBus;
using System.Threading;
using System.Threading.Tasks;

namespace Overload.Payment.Application.TransactionPayments.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, Unit>
    {
        private readonly IEventBus _eventBus;

        public GetTransactionsQueryHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
