using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Communication.Resources.Save;

public class LikeSaveResource
{
    [Required] public int PostId { get; set; }
}