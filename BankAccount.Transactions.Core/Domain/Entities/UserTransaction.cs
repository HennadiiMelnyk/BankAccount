using BankAccount.Shared.Application.Models;

namespace BankAccount.Transactions.Core.Domain.Entities
{
    /// <summary>
    /// Transaction.
    /// </summary>
    public class UserTransaction
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid Id { get; set; }
    
        /// <summary>
        /// Amount.
        /// </summary>
        public decimal Amount { get; set; }
    
        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// Transaction operations.
        /// </summary>
        public Operation Operation { get; set; }
        
        /// <summary>
        /// Transaction creation time.
        /// </summary>
        public DateTimeOffset TransactionCreationTime { get; set; }
    }
}