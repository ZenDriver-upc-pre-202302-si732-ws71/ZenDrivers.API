using System.ComponentModel.DataAnnotations;
using ZenDrivers.API.Drivers.Resources.Update;

namespace ZenDrivers.API.Drivers.Resources.Save;

public class LicenseSaveResource : LicenseUpdateResource
{
    [Required]
    public int CategoryId { get; set; }
}