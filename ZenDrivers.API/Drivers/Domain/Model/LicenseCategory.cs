using ZenDrivers.API.Drivers.Resources;

namespace ZenDrivers.API.Drivers.Domain.Model;

public class LicenseCategory : LicenseCategoryResource
{
    public string Name { get; set; } = null!;
}