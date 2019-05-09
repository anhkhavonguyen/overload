using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Overload.Payment.Application.TransactionPayments.Queries.GetAllTransactionPayments
{
    public class GetAllTransactionPaymentQueryHandler : IRequestHandler<GetAllTransactionPaymentQuery, Unit>
    {
        public Task<Unit> Handle(GetAllTransactionPaymentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
