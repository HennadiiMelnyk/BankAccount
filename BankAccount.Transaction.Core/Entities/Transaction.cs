namespace BankAccount.Transaction.Core.Entities;

public class Transaction
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public decimal Amount { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public Guid UserId { get; set; }
    
}