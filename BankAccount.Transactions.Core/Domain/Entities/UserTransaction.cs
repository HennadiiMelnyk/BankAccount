namespace BankAccount.Transactions.Core.Domain.Entities
{
    /// <summary>
    /// Transaction.
    /// </summary>
    public class UserTransaction
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
        
        /// <summary>
        /// Transaction operations.
        /// </summary>
        public Operation Operation { get; set; }
    }
}