using ZenDrivers.API.Security.Domain.Models;

namespace ZenDrivers.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(Account account);
    public int? ValidateToken(string token);
}
