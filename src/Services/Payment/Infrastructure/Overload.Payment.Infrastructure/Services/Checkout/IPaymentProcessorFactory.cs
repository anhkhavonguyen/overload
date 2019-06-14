using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Services.Checkout
{
    public interface IPaymentProcessorFactory
    {
        Task Process(string method, decimal amount);
    }
}