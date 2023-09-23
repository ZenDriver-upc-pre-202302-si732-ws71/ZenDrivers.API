using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Recruiters.Resources.Update;

public class PostUpdateResource
{
    [Required]
    
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Image { get; set; }
}