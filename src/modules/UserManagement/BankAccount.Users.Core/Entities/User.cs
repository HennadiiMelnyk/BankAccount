namespace BankAccountApi.Accounts.Core.Entities
{
    /// <summary>
    /// User entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid Id { get; set; }
    
        /// <summary>
        /// Customer id.
        /// </summary>
        public int CustomerId { get; set; }
    
        /// <summary>
        /// FirstName.
        /// </summary>
        public string? FirstName { get; set; }
    
        /// <summary>
        /// Last name.
        /// </summary>
        public string? LastName { get; set; }
    
        /// <summary>
        /// Balance.
        /// </summary>
        public decimal Balance { get; set; }
    }
}