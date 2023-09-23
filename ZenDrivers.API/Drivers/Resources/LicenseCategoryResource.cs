using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Drivers.Resources;

public class LicenseCategoryResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}