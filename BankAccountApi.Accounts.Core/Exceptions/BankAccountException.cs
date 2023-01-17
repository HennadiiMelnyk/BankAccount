using System.Net;

namespace BankAccountApi.Accounts.Core.Exceptions;

public class BankAccountException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccountException"/> class.
    /// </summary>
    public BankAccountException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccountException"/> class.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    /// <param name="httpStatusCode">The http status code.</param>
    public BankAccountException(string errorMessage, HttpStatusCode httpStatusCode)
        : base(errorMessage)
    {
        this.StatusCode = httpStatusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccountException"/> class.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    public BankAccountException(string errorMessage)
        : base(errorMessage)
    {
    }

    /// <summary>Gets HTTP Status Code.</summary>
    public HttpStatusCode StatusCode { get; }
}