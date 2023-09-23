using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Security.Resources;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Drivers.Resources;

public class LicenseResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
    public LicenseCategoryResource Category { get; set; } = null!;

    public DriverResource Driver { get; set; } = null!;

}