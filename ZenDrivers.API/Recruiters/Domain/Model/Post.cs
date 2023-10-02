using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Recruiters.Domain.Model;

public class Post : PostResource
{
    public Post()
    {
        Date = DateTime.Now;
    }
    public int RecruiterId { get; set; }
    public new Recruiter Recruiter { get; set; } = null!;
    public new IEnumerable<Like> Likes { get; set; } = null!;
    public new IEnumerable<Comment> Comments { get; set; } = null!;
}