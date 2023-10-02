using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Recruiters.Resources;

public class PostSimpleResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public DateTime Date { get; set; }
    public RecruiterResource Recruiter { get; set; } = null!;
}