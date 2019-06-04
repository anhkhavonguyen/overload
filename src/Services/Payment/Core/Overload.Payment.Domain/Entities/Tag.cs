using Overload.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Overload.Payment.Domain.Entities
{
    public class Tag: EntityBase
    {
        public string AccountId { get; set; }
        public Account Account { get; set; }
        //public TagState State { get; set; }
        public string TagNumber { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public ICollection<CompositeTransaction> CompositeTransactions { get; set; }
    }
}
