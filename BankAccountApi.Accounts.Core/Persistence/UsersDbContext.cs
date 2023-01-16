using BankAccountApi.Accounts.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankAccountApi.Accounts.Core.Persistence;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }
    
    public virtual DbSet<User> Users { get; set; } = null!;
}