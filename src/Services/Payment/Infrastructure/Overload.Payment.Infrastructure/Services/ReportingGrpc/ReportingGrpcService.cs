using System.Threading.Tasks;
using Overload.Reporting;

namespace Overload.Payment.Infrastructure.Services.ReportingGrpc
{
    public class ReportingGrpcService: BaseGrpcClientService, IReportingGrpcService
    {
        private Reporting.Reporting.ReportingClient _client = null;

        public ReportingGrpcService(string host) : base(host)
        {
            _client = new Reporting.Reporting.ReportingClient(this._channel);
        }

        public async Task ExecuteAsync()
        {
            var request = new TransactionRequest();
            var reply = await _client.TransactionAsync(request);
        }

        public Task<object> PrepareData()
        {
            throw new System.NotImplementedException();
        }
    }
}
