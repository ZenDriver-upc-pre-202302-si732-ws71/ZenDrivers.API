using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Recruiters.Resources.Update;

public class PostUpdateResource
{
    [Required]
    public string Title { get; set; } = null!;

    [Required] 
    public string Description { get; set; } = null!;
    
    public string? Image { get; set; }
}