using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Resources;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Drivers.Resources;

public class DriverResource : DriverSimpleResource
{
   public IEnumerable<LicenseResource> Licenses { get; set; } = null!;
   public IEnumerable<DriverExperienceResource> Experiences { get; set; } = null!;
}