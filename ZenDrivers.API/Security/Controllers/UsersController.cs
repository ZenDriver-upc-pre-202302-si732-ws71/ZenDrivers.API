using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Services;
using ZenDrivers.API.Security.Domain.Services.Communication;
using ZenDrivers.API.Security.Resources;
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Security.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public UsersController(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _accountService.Authenticate(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _accountService.RegisterAsync(request);
        return Ok(new { message = "Registration successfull" });
    }

    [AllowAnonymous]
    [HttpPost("validate")]
    public async Task<IActionResult> Validate(ValidationRequest request)
    {
        if (await _accountService.ValidateAsync(request) is { } _)
            return Ok(ErrorResponse.Of("The token and username are valid"));

        return BadRequest(ErrorResponse.Of("Invalid token or username"));
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        if (HttpContext.Items["User"] is not Account account)
            return BadRequest("Invalid credentials");

        var response = await _accountService.ChangePassword(account.Username, request);
        
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _accountService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountResource>>(users);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById (int id)
    {
      var user = await _accountService.GetByIdAsync(id);
      var resource = _mapper.Map<Account, AccountResource>(user);
        return Ok(resource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _accountService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _accountService.DeleteAsync(id);
        return Ok(new { message = "User deleted succesfully" });
    }

    [HttpGet("search/")]
    public async Task<IActionResult> FindByUsernameAsync([FromQuery] string username)
    {
        var response = await _accountService.FindByUsernameAsync(username);

        return response.Success ? Ok(_mapper.Map<AccountResource>(response.Resource)) : BadRequest(ErrorResponse.Of(response.Message));
    }
    
}
