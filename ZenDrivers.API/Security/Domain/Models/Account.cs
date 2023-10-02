using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Shared.Domain.Enums;
using ZenDrivers.API.Shared.Extensions;

namespace ZenDrivers.API.Security.Domain.Models;
public class Account
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public UserType Role { get; set; }
    public string Phone { get; set; } = null!;
    
    public string? ImageUrl { get; set; }
    public Recruiter? Recruiter { get; set; }
    public Driver? Driver { get; set; }

    public bool ValidNames() => Firstname.IsName() && Lastname.IsName();

    public bool ValidPhone() => Phone.HasOnlyNumbers();

}