using BankAccount.Shared.Application.RequestModels;
using BankAccount.Shared.Application.RequestModelValidators;
using BankAccount.Shared.Application.ResponseModels;
using BankAccount.Shared.Infrastructure.Controllers;
using BankAccountApi.Accounts.Core.Domain.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountApi.Accounts.Api.Controllers;

/// <summary>
/// Contains the endpoints to work with users.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IValidator<UserRequestModel> _userFilterRequestValidator;

    public UserController(IUserService userService, IValidator<UserRequestModel> userFilterRequestValidator)
    {
        _userService = userService;
        _userFilterRequestValidator = userFilterRequestValidator;
    }


    /// <summary>
    /// Get customer info.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    public async Task<IActionResult> GetUserById([FromRoute]Guid id, CancellationToken ct)
    {
        return Ok(await _userService.GetUserByIdAsync(id, ct));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userRequestModel"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseModel))]
    public async Task<IActionResult> AddUser([FromBody] UserRequestModel userRequestModel, CancellationToken ct)
    {
        UserRequestModelValidator modelValidator = new();
        var validationResult = await modelValidator.ValidateAsync(userRequestModel, ct);
        if (validationResult.IsValid)
        {
            var result = await _userService.CreateAsync(userRequestModel,ct);
            return Created($"api/user/{result.Id}", result);
        }

        return BadRequest(validationResult.Errors);
    }
}