using System.Threading.Tasks;
using Grpc.Core;

namespace Overload.Reporting.Service.Services
{
    public class ReportingService : Reporting.ReportingBase
    {
        public override Task<TransactionResponse> Transaction(TransactionRequest request, ServerCallContext context)
        {
            return base.Transaction(request, context);
        }
    }
}
