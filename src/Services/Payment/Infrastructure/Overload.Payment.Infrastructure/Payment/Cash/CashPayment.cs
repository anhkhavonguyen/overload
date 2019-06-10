using Overload.Payment.Persistence;
using System.Threading.Tasks;

namespace Overload.Payment.Infrastructure.Payment
{
    public class CashPayment : BasePayment, ICashPayment
    {
        private readonly OverloadDbContext _dbContext;
        public CashPayment()
        {
            //_dbContext = dbContext;
        }

        public override void Execute(dynamic TEvent)
        {
            //TODO: Save Changes Db
        }

        public Task Process(dynamic TEvent)
        {
            return Task.CompletedTask;
        }

        public Task ProcessFail()
        {
            return Task.CompletedTask;
        }

        public Task ProcessSuccessful()
        {
            return Task.CompletedTask;
        }
    }
}
