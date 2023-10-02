using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Security.Resources;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Communication.Resources;

public class CommentResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public AccountSimpleResource Account { get; set; } = null!;
    public DateTime Date { get; set; }
    
    public int PostId { get; set; }
}