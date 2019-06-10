using Microsoft.AspNetCore.Mvc;
using Overload.Payment.Infrastructure.Services.Checkout;
using System.Threading.Tasks;

namespace Overload.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : BaseController
    {
        private readonly PaymentProcessorFactory _paymentProcessor;
        public CheckoutController(PaymentProcessorFactory paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(string method)
        {
            //Client
            await _paymentProcessor.Process(method);
            return Ok();
        }
    }
}