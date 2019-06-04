using Overload.Domain;

namespace Overload.Payment.Domain.Entities
{
    public class CompositeTransaction: AggregateRoot
    {
        public string FromAccountId { get; set; }
        public virtual Account FromAccount { get; set; }
        public string ToAccountId { get; set; }
        public virtual Account ToAccount { get; set; }
        public TransactionType Type { get; set; }
        public PaymentType PaymentType { get; set; }
        public string ExternalBankId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionNote { get; set; }
        public string TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
