namespace BankAccountApi.Accounts.Core.RequestModels;

public class UserRequestModel
{
    /// <summary>
    /// Customer id.
    /// </summary>
    public int CustomerId { get; init; }
    
    /// <summary>
    /// First name.
    /// </summary>
    public string FirstName { get; init; } = null!;
    
    /// <summary>
    /// last name.
    /// </summary>
    public string LastName { get; init; }  = null!;
    
    /// <summary>
    /// initial credit.
    /// </summary>
    public decimal InitialCredit { get; init; }
}