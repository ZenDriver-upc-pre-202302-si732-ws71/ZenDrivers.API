using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Drivers.Resources;

public class DriverExperienceResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
}