using BankAccountApi.Accounts.Core.Entities;
using BankAccountApi.Accounts.Core.Persistence;
using BankAccountApi.Accounts.Core.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BankAccountApi.Accounts.Core.Repositories;

/// <summary>
/// 
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly UsersDbContext _context;

    public UserRepository(UsersDbContext context)
    {
        _context = context;
    }
    
    public Task<User?> FindByUserIdAsync(Guid userId, CancellationToken ct)
        => _context.Users.FirstOrDefaultAsync(x => x.Id == userId, ct);

    public Task<User?> FindByCustomerIdAsync(int customerId, CancellationToken ct)
        => _context.Users.FirstOrDefaultAsync(x => x.CustomerId == customerId, ct);

    public async Task<User> AddAsync(User entity, CancellationToken ct)
    {
        var addedEntity = await _context.Users.AddAsync(entity, ct);

        return addedEntity.Entity;
    }

    public Task SaveChangesAsync(CancellationToken ct)
        => _context.SaveChangesAsync(ct);
}