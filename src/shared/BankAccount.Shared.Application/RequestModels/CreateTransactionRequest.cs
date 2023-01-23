using BankAccount.Shared.Application.Models;

namespace BankAccount.Shared.Application.RequestModels;

public class CreateTransactionRequest
{
    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }
    
    /// <summary>
    /// Amount.
    /// </summary>
    public decimal Amount { get; init; }
    
    /// <summary>
    /// Operation.
    /// </summary>
    public Operation Operation { get; init; }
}