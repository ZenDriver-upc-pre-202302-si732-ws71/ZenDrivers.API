using ZenDrivers.API.Drivers.Resources;
using ZenDrivers.API.Recruiters.Resources;

namespace ZenDrivers.API.Security.Resources;

public class AccountResource
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string? ImageUrl { get; set; }
    
    public AccountRecruiterResource? Recruiter { get; set; }
    public AccountDriverResource? Driver { get; set; }
}
