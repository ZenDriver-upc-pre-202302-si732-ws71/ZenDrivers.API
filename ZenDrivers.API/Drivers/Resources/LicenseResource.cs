using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Drivers.Resources;

public class LicenseResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public LicenseCategory Category { get; set; } = null!;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}