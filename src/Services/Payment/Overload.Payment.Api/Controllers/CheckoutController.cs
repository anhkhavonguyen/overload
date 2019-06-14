using Microsoft.AspNetCore.Mvc;
using Overload.Payment.Infrastructure.Services.Checkout;
using System.Threading.Tasks;

namespace Overload.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : BaseController
    {
        private readonly IPaymentProcessorFactory _paymentProcessor;
        public CheckoutController(IPaymentProcessorFactory paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(string method, decimal amount)
        {
            //Client
            await _paymentProcessor.Process(method, amount);
            return Ok();
        }
    }
}