using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Services.ReportingGrpc
{
    public interface IReportingGrpcService
    {
        Task<object> PrepareData();
        Task ExecuteAsync();
    }
}
