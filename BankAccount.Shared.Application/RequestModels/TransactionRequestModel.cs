namespace BankAccount.Shared.Application.RequestModels;

public class TransactionRequestModel
{
    public Guid UserId { get; init; }
    public decimal Amount { get; init; }
    public string? Operation { get; init; }
}