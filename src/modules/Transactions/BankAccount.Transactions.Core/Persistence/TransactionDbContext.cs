using BankAccount.Transactions.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Transactions.Core.Persistence
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
        }

        public virtual DbSet<UserTransaction> Transactions { get; set; }   
    }
}