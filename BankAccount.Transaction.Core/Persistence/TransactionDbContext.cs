using Microsoft.EntityFrameworkCore;

namespace BankAccount.Transaction.Core.Persistence;

public class TransactionDbContext : DbContext
{
    public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Entities.Transaction> Transactions { get; set; }   
}