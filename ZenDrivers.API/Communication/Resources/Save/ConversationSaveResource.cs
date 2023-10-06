using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Communication.Resources.Save;

public class ConversationSaveResource
{
    [Required] public string ReceiverUsername { get; set; } = null!;
}