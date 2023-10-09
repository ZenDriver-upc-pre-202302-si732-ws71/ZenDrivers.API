using ZenDrivers.API.Security.Resources;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Communication.Resources;

public class ConversationResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public AccountSimpleResource Sender { get; set; } = null!;
    public AccountSimpleResource Receiver { get; set; } = null!;
    
    public IEnumerable<MessageResource> Messages { get; set; } = null!;
}