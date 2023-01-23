using FluentValidation.Results;

namespace BankAccount.Shared.Application.Extensions;

/// <summary>
/// Fluent validation result extensions.
/// </summary>
public static class ValidationResultExtensions
{
    /// <summary>
    /// Get error messages.
    /// </summary>
    /// <param name="validationResult">Fluent validation result model.</param>
    /// <returns>Error messages as string.</returns>
    public static string GetErrorMessages(this ValidationResult validationResult)
    {
        var errorMessages = validationResult.Errors
            .Select(x => x.ErrorMessage);

        return string.Join(string.Empty, errorMessages);
    }
}
