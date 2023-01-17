namespace BankAccountApi.Accounts.Core.Entities;

/// <summary>
/// 
/// </summary>
public class User
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public int CustomerId { get; set; }
    
    /// <summary>
    ///
    /// </summary>
    public string? FirstName { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public decimal Balance { get; set; }
}