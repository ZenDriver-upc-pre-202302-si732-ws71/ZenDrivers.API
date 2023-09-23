using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Drivers.Resources.Save;

public class DriverSaveResource
{
    [Required] 
    public string Address { get; set; } = null!;
    [Required]
    public DateTime Birth { get; set; }
}