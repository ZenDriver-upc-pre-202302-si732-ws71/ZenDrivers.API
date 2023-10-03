using ZenDrivers.API.Drivers.Resources;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Drivers.Domain.Model;

public class Driver : DriverResource
{
    public new Account Account { get; set; } = null!;
    public new IEnumerable<License> Licenses { get; set; } = null!;
    public new IEnumerable<DriverExperience> Experiences { get; set; } = null!;
    public int AccountId { get; set; }
}