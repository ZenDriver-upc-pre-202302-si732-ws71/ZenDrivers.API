using ZenDrivers.API.Security.Resources;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Drivers.Resources;

public class DriverSimpleResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public string Address { get; set; } = null!;
    
    public DateTime Birth { get; set; }
    public AccountSimpleResource Account { get; set; } = null!;
}