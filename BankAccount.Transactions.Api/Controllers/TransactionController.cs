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
    public class TransactionController : BaseController<CreateTransactionRequest>
    {
        private ITransactionService _transactionService;
        private readonly IValidator<CreateTransactionRequest> _validator;
        public TransactionController(IValidator<CreateTransactionRequest> modelValidator, IValidator<CreateTransactionRequest> validator, ITransactionService transactionService) : base(modelValidator)
        {
            _validator = validator;
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