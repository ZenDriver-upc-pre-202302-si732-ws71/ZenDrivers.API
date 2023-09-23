using ZenDrivers.API.Drivers.Resources;

namespace ZenDrivers.API.Drivers.Domain.Model;

public class License : LicenseResource
{
    public new LicenseCategory Category { get; set; } = null!;
    public new Driver Driver { get; set; } = null!;
    public int DriverId { get; set; }
    public int CategoryId { get; set; }
}