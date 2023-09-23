

using ZenDrivers.API.Communication.Resources.Update;

namespace ZenDrivers.API.Communication.Resources.Save;

public class MessageSaveResource : MessageUpdateResource
{

    public string ReceiverUsername { get; set; } = null!;
}