using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Payment
{
    public interface ICashPayment
    {
        Task Process(dynamic TEvent);
    }
}
