using System.Net;
using System.Text.Json;
using BankAccount.Shared.Application.Exceptions;
using BankAccount.Shared.Application.ResponseModels;
using Microsoft.AspNetCore.Http;

namespace BankAccount.Shared.Application.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorHandlingMiddleware"/> class.
    /// </summary>
    /// <param name="next">Request delegate.</param>
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Invoke.
    /// </summary>
    /// <param name="context">Current HTTP context.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BankAccountException ex)
        {
            await HandleExceptionAsync(context, ex, ex.StatusCode);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    {
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        var error = new ErrorResponseModel { Code = statusCode.ToString(), Message = exception.Message };
        await context.Response.WriteAsync(JsonSerializer.Serialize(error));
    }
}
