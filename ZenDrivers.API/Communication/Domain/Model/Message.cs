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
    
    public int ConversationId { get; set; }
}