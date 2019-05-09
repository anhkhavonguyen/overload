using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Overload.Payment.Application.TransactionPayments.Queries.GetAllTransactionPayments;
using System.Collections.Generic;
using Overload.EventBus;
using Overload.Payment.Infrastructure.Events;

namespace Overload.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionPaymentsController : BaseController
    {
        private readonly IEventBus _eventBus;
        public TransactionPaymentsController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = new List<string>();
            result.Add("test");
            var @event = new PaymentExecutedEvent();
            await _eventBus.PublishAsync(@event);
            //var result = await Mediator.Send(new GetAllTransactionPaymentQuery());
            return Ok(result);
        }
    }
}
