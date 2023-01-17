using System.Net;
using BankAccount.Shared.Application.Extensions;
using BankAccount.Shared.Application.ResponseModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace BankAccount.Shared.Api.Controllers
{
    /// <summary>
    /// Base controller.
    /// </summary>
    /// <typeparam name="TRequestModel">The request model.</typeparam>
    public class BaseController<TRequestModel> : Controller
    {
        /// <summary>
        /// Model validator.
        /// </summary>
        protected readonly IValidator<TRequestModel> ModelValidator;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController{TRequestModel}"/> class.
        /// </summary>
        /// <param name="modelValidator">The model validator.</param>
        public BaseController(IValidator<TRequestModel> modelValidator)
        {
            ModelValidator = modelValidator;
        }

        /// <summary>
        /// Is request model valid.
        /// </summary>
        /// <param name="requestModel">TRequest model.</param>
        /// <returns>True or false.</returns>
        protected Task<ValidationResult> IsModelValidAsync(TRequestModel requestModel)
            => ModelValidator.ValidateAsync(requestModel);

        /// <summary>
        /// Return Model not valid response.
        /// </summary>
        /// <param name="validationResult">Validation result.</param>
        /// <returns>BadRequest response.</returns>
        protected IActionResult ModelNotValidResponse(ValidationResult validationResult)
        {
            var errorModel = new ErrorResponseModel
            {
                Code = HttpStatusCode.BadRequest.ToString(),
                Message = validationResult.GetErrorMessages()
            };
            return BadRequest(errorModel);
        }
    }
}