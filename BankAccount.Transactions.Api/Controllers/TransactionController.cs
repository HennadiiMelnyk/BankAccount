using BankAccount.Shared.Application.RequestModels;
using BankAccount.Shared.Infrastructure.Controllers;
using BankAccount.Transactions.Core.Domain.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BankAccount.Transactions.Api.Controllers
{
    /// <summary>
    /// Contains the endpoints to work with user transactions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserTransaction([FromRoute] Guid userId, CancellationToken ct)
        {
            return Ok(await _transactionService.GetTransactionsForUserAsync(userId, ct));
        }
    }
}