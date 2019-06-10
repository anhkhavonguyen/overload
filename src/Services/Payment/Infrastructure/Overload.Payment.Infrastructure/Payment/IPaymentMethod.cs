using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Payment
{
    public interface IPaymentMethod
    {
        Task ExecuteAsync(dynamic TEvent);

        Task ExecuteSuccessful();

        Task ExecuteFail();
    }
}
