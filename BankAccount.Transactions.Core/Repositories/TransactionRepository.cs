using BankAccount.Transactions.Core.Domain.Entities;
using BankAccount.Transactions.Core.Persistence;
using BankAccount.Transactions.Core.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Transactions.Core.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDbContext _context;

        public TransactionRepository(TransactionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserTransaction>> GetByUserId(Guid userId, CancellationToken ct)
            => await _context.Transactions
                .Where(x => x.UserId == userId)
                .ToListAsync(cancellationToken: ct);

        public async Task<UserTransaction> AddAsync(UserTransaction entity, CancellationToken ct)
        {
            var result = await _context.Transactions.AddAsync(entity, ct);

            return result.Entity;
        }

        public Task SaveChangesAsync(CancellationToken ct)
            => _context.SaveChangesAsync(ct);
    }
}