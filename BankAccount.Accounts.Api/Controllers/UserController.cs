using BankAccount.Shared.Application.RequestModels;
using BankAccountApi.Accounts.Core.Domain.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountApi.Accounts.Api.Controllers;

/// <summary>
/// Contains the endpoints to work with users.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController<UserRequestModel>
{
    private IUserService _userService;
    private readonly IValidator<UserRequestModel> _userFilterRequestValidator;

    public UserController(IUserService userService, IValidator<UserRequestModel> userFilterRequestValidator) : base(userFilterRequestValidator)
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
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    [Produces("application/json")]
    public async Task<IActionResult> AddUser([FromBody] UserRequestModel request, CancellationToken ct)
    {
        var validationResult = await IsModelValidAsync(request)
            .ConfigureAwait(false);
        if (validationResult.IsValid)
        {
            var result = await _userService.CreateAsync(request,ct);
            return Created($"api/user/{result.Id}", result);
        }

        return ModelNotValidResponse(validationResult);
    }
}