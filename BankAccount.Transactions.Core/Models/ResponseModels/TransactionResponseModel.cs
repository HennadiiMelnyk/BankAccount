namespace BankAccount.Transactions.Core.Models.ResponseModels
{
    public class TransactionResponseModel
    {
        public Guid Id { get; init; }
        public decimal Amount { get; init; }
        public Guid UserId { get; init; }
        public string? Operation { get; init; }
    }
}