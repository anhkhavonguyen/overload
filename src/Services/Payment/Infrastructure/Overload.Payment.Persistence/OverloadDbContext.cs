using Microsoft.EntityFrameworkCore;
using Overload.Payment.Domain.Entities;

namespace Overload.Payment.Persistence
{
    public class OverloadDbContext : DbContext
    {
        public OverloadDbContext(DbContextOptions<OverloadDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<CompositeTransaction>().ToTable("CompositeTransaction");
            modelBuilder.Entity<Merchant>().ToTable("Merchant");
            modelBuilder.Entity<Dim>().ToTable("Dim");
            modelBuilder.Entity<TransactionPayment>().ToTable("TransactionPayment");
            modelBuilder.Entity<Tag>().ToTable("Tag");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<CompositeTransaction> CompositeTransactions { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Dim> Dims { get; set; }
        public DbSet<TransactionPayment> TransactionPayments { get; set; }
    }
}
