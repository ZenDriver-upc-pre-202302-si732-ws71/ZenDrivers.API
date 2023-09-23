using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Resources.Update;

namespace ZenDrivers.API.Security.Domain.Services.Communication;

public class UpdateRequest
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public RecruiterUpdateResource? Recruiter { get; set; }
    public DriverUpdateResource? Driver { get; set; }
}