namespace BankAccount.Transactions.Core.ResponseModels
{
    /// <summary>
    /// Transaction response model.
    /// </summary>
    public class TransactionResponseModel
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid Id { get; init; }
        
        /// <summary>
        /// Amount.
        /// </summary>
        public decimal Amount { get; init; }
        
        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; init; }
        
        /// <summary>
        /// Operation Type.
        /// </summary>
        public string? Operation { get; init; }
    }
}