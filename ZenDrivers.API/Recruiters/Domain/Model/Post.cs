using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Recruiters.Domain.Model;

public class Post : PostResource
{
    public int RecruiterId { get; set; }
    public new Recruiter Recruiter { get; set; } = null!;
}