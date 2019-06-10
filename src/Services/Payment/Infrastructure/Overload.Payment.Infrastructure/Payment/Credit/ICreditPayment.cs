using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Payment
{
    public interface ICreditPayment
    {
        Task Process(dynamic TEvent);
    }
}
