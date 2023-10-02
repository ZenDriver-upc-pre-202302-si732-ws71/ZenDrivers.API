using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Security.Domain.Services.Communication;

public class ValidationRequest
{
    [Required] public string Username { get; set; } = null!;
    [Required] public string Token { get; set; } = null!;
}