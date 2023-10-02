using ZenDrivers.API.Communication.Resources;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Security.Domain.Models;

namespace ZenDrivers.API.Communication.Domain.Model;

public class Like : LikeResource
{
    public new Account Account { get; set; } = null!;
    
    public int AccountId { get; set; }
    public Post Post { get; set; } = null!;
    
}