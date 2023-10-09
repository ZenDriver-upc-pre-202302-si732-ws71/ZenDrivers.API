namespace ZenDrivers.API.Security.Domain.Services.Communication;

public class ChangePasswordRequest
{
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}