using System;

namespace Overload.Domain
{
    public abstract class EntityBase
    {
        public EntityBase()
        {

        }

        public Guid Id { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
