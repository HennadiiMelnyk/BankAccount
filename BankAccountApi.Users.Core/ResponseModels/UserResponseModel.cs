namespace BankAccountApi.Accounts.Core.ResponseModels
{
    public class UserResponseModel
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid Id { get; init; }
    
        /// <summary>
        /// Customer id.
        /// </summary>
        public int CustomerId { get; init; }
    
        /// <summary>
        /// First name.
        /// </summary>
        public string? FirstName { get; init; }
    
        /// <summary>
        /// Last name.
        /// </summary>
        public string? LastName { get; init; }
    
        /// <summary>
        /// User Account balance.
        /// </summary>
        public decimal Balance { get; init; }
    }
}