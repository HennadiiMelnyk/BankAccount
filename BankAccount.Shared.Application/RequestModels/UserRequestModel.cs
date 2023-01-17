namespace BankAccount.Shared.Application.RequestModels;

public class UserRequestModel
{
    /// <summary>
    /// 
    /// </summary>
    public int CustomerId { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    public string FirstName { get; init; } = null!;
    
    /// <summary>
    /// 
    /// </summary>
    public string LastName { get; init; }  = null!;
    
    /// <summary>
    /// 
    /// </summary>
    public decimal InitialCredit { get; init; }
}