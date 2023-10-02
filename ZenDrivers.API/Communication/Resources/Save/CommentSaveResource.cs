using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Communication.Resources.Save;

public class CommentSaveResource
{
    [Required] public string Content { get; set; } = null!;
    [Required] public int PostId { get; set; }
}