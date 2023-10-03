using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Drivers.Resources;

public class LicenseResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
    public LicenseCategoryResource Category { get; set; } = null!;

    public DriverSimpleResource Driver { get; set; } = null!;

}