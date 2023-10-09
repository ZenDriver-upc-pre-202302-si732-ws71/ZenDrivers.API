using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Services.Communication;
using ZenDrivers.API.Shared.Domain.Enums;
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Security.Domain.Services;
public interface IAccountService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    Task<AuthenticateResponse> ChangePassword(string username, ChangePasswordRequest request);
    Task<Account?> ValidateAsync(ValidationRequest request);    
    Task<IEnumerable<Account>> ListAsync();
    Task<Account> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest model);
    Task UpdateAsync(int id, UpdateRequest model);
    Task DeleteAsync(int id);
    
    Task<Account?> FindByUsernameAsync(string username);
    Task<IEnumerable<Account>> FindByUserRoleAsync(UserType role);
}
