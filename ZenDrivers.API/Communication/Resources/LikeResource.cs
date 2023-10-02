using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Security.Resources;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Communication.Resources;

public class LikeResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public AccountSimpleResource Account { get; set; } = null!;
    public int PostId { get; set; }
}