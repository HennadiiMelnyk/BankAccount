using BankAccount.Transaction.Core.Persistence;
using BankAccount.Transaction.Core.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace BankAccount.Transaction.Core.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly TransactionDbContext _context;

    public TransactionRepository(TransactionDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetByUserId(Guid userId, CancellationToken ct)
        => await _context.Transactions
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken: ct);

    public async Task<Transaction> AddAsync(Transaction entity, CancellationToken ct)
    {
        var result = await _context.Transactions.AddAsync(entity, ct);

        return result;
    }

    public Task SaveChangesAsync(CancellationToken ct)
        => _context.SaveChangesAsync(ct);
}