using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Overload.Payment.Application.TransactionPayments.Queries.GetAllTransactionPayments;

namespace Overload.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionPaymentsController : BaseController
    {      
        public TransactionPaymentsController()
        {
          
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {         
            var result = await Mediator.Send(new GetAllTransactionPaymentQuery());
            return Ok(result);
        }
    }
}
