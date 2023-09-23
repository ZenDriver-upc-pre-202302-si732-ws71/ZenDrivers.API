using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Communication.Resources.Requests;

public class ConversationRequest
{
    [Required] public string ReceiverUsername { get; set; } = null!;
    [Required] public string SenderUsername { get; set; } = null!;
}