using Overload.Domain;
using Overload.Payment.Common;
using System;
using System.Collections.Generic;

namespace Overload.Payment.Domain.Entities
{
    public class TransactionPayment: EntityBase
    {
        public TransactionPayment()
        {
            CompositeTransactions = new HashSet<CompositeTransaction>();
        }

        public string OrderId { get; set; }
        public string DimUnitId { get; set; }
        public StatusCode StatusCode { get; set; }
        public string PaymentCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartTime { get; set; }
        public string PaymentChannel { get; set; }
        public string Action { get; set; }
        public int CustomerTokenCalc { get; set; }
        public string TransactionPaymentType { get; set; }
        public ICollection<CompositeTransaction> CompositeTransactions { get; set; }
    }
}
