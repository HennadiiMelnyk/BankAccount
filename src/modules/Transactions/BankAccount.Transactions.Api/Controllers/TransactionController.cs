using BankAccount.Transactions.Core.Domain.Services.Contracts;
using BankAccount.Transactions.Core.ResponseModels;
using Microsoft.AspNetCore.Http;
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

        [HttpGet($"/users/"+"{userId:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransactionResponseModel))]
        public async Task<IActionResult> GetUserTransaction([FromRoute] Guid userId, CancellationToken ct)
        {
            return Ok(await _transactionService.GetTransactionsForUserAsync(userId, ct));
        }
    }
}