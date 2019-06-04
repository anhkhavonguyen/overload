using System.Threading.Tasks;
using Overload.Reporting;

namespace Overload.Payment.Infrastructure.Services.ReportingGrpc
{
    public class ReportingGrpcService: BaseGrpcClientService, IReportingGrpcService
    {
        private Reporting.Reporting.ReportingClient _client = null;

        public ReportingGrpcService(string host) : base(host)
        {

        }

        public Task ExecuteAsync()
        {
            var request = new TransactionRequest();
            var reply = _client.TransactionAsync(request);

            return Task.CompletedTask;
        }

        public Task<object> PrepareData()
        {
            throw new System.NotImplementedException();
        }
    }
}
