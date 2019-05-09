using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Overload.Payment.Domain.Entities;

namespace Overload.Payment.Persistence.Configurations
{
    public class TransactionPaymentConfiguration : IEntityTypeConfiguration<TransactionPayment>
    {
        public void Configure(EntityTypeBuilder<TransactionPayment> builder)
        {
            builder.Property(e => e.Id).HasColumnName("Id");
        }
    }
}
