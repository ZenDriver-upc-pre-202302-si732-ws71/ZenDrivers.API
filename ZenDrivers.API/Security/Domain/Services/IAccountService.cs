﻿using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Services.Communication;
using ZenDrivers.API.Shared.Domain.Enums;

namespace ZenDrivers.API.Security.Domain.Services;
public interface IAccountService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<Account>> ListAsync();
    Task<Account> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest model);
    Task UpdateAsync(int id, UpdateRequest model);
    Task DeleteAsync(int id);
    
    Task<Account?> FindByUsernameAsync(string username);
    Task<IEnumerable<Account>> FindByUserRoleAsync(UserType role);
    Account? FindByUsername(string username);
}
