using ZenDrivers.API.Communication.Resources;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Security.Domain.Models;

namespace ZenDrivers.API.Communication.Domain.Model;

public class Message : MessageResource
{
    public Message()
    {
        Date = DateTime.Now;
    }
    public new Account Receiver { get; set; } = null!;
    public int ReceiverId { get; set; }
    public new Account Sender { get; set; } = null!;
    public int SenderId { get; set; }
}