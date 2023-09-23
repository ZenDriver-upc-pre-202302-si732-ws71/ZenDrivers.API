using System.ComponentModel.DataAnnotations;
using ZenDrivers.API.Drivers.Resources.Save;
using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Recruiters.Resources.Save;
using ZenDrivers.API.Shared.Domain.Enums;

namespace ZenDrivers.API.Security.Domain.Services.Communication;
public class RegisterRequest
{
    [Required]
    public string Firstname { get; set; } = null!;
    [Required]
    public string Lastname { get; set; } = null!;
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    

    public string Phone { get; set; } = null!;
    [Required] 
    public string Role { get; set; } = null!;

    public RecruiterSaveResource? Recruiter { get; set; }
    public DriverSaveResource? Driver { get; set; }
}