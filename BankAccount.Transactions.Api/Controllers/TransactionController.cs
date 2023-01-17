using BankAccount.Shared.Api.Controllers;
using BankAccount.Shared.Application.RequestModels;
using BankAccount.Transaction.Core.Domain.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BankAccount.Transactions.Api.Controllers
{
    /// <summary>
    /// Contains the endpoints to work with user transactions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : BaseController<TransactionRequestModel>
    {
        private ITransactionService _transactionService;
        private readonly IValidator<TransactionRequestModel> _validator;
        public TransactionController(IValidator<TransactionRequestModel> modelValidator, IValidator<TransactionRequestModel> validator, ITransactionService transactionService) : base(modelValidator)
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