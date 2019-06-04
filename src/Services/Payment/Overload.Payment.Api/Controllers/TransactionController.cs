using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Overload.Payment.Application.TransactionPayments.Queries.GetTransactions;
using Overload.Payment.Infrastructure.Services.ReportingGrpc;

namespace Overload.Payment.Api.Controllers
{
    [Route("api/Transactions")]
    public class TransactionController : BaseController
    {
        private IReportingGrpcService _reportingGrpcService;
        public TransactionController(IReportingGrpcService reportingGrpcService)
        {
            _reportingGrpcService = reportingGrpcService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetTransactionsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Report()
        {
            await _reportingGrpcService.ExecuteAsync();
            return Ok();
        }
    }
}
