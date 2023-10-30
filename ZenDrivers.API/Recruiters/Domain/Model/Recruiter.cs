using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Recruiters.Domain.Model;

public class Recruiter : RecruiterResource
{
    public int CompanyId { get; set; }
    
    public new Company Company { get; set; } = null!;
    public int AccountId { get; set; }
    public new Account Account { get; set; } = null!;
    
    public bool Verified { get; set; }
}