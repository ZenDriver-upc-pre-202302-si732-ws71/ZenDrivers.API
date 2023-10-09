using ZenDrivers.API.Security.Resources;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Recruiters.Resources;

public class RecruiterResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string? Description { get; set; }
    
    public CompanyResource Company { get; set; } = null!;
    public AccountSimpleResource Account { get; set; } = null!;
}