using ZenDrivers.API.Communication.Resources;
using ZenDrivers.API.Security.Domain.Models;

namespace ZenDrivers.API.Communication.Domain.Model;

public class Conversation : ConversationResource
{
    public new Account Receiver { get; set; } = null!;
    public int ReceiverId { get; set; }
    public new Account Sender { get; set; } = null!;
    public int SenderId { get; set; }
    public new IEnumerable<Message> Messages { get; set; } = null!;
}