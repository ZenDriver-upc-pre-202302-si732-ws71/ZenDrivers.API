using System.ComponentModel.DataAnnotations;
using ZenDrivers.API.Drivers.Resources.Update;

namespace ZenDrivers.API.Drivers.Resources.Save;

public class LicenseSaveResource : LicenseUpdateResource
{
    [Required]
    public int CategoryId { get; set; }
    
    [Required]
    public DateTime Start { get; set; }
    
    [Required]
    public DateTime End { get; set; }
}