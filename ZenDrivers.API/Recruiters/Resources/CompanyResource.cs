using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Recruiters.Resources;

public class CompanyResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Ruc { get; set; } = null!;
    public string Owner { get; set; } = null!;
    public string Address { get; set; } = null!;
    
}