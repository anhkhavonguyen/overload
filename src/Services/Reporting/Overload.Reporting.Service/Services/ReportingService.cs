using System.Threading.Tasks;
using Grpc.Core;

namespace Overload.Reporting.Service.Services
{
    public class ReportingService : Reporting.ReportingBase
    {
        public override Task<TransactionPaymentResponse> TransactionPayment(TransactionPaymentRequest request, ServerCallContext context)
        {
            return base.TransactionPayment(request, context);
        }
    }
}
