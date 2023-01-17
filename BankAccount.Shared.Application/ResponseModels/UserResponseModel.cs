namespace BankAccount.Shared.Application.ResponseModels;

public class UserResponseModel
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    public int CustomerId { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? FirstName { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? LastName { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    public decimal Balance { get; init; }
}