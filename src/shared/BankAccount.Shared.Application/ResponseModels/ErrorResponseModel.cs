namespace BankAccount.Shared.Application.ResponseModels;

/// <summary>
/// Error response model.
/// </summary>
public class ErrorResponseModel
{
    /// <summary>
    /// Gets or sets a code.
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets a message.
    /// </summary>
    public string? Message { get; set; }
}