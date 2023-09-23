using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Drivers.Resources.Update;

public class DriverExperienceUpdateResource
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; } = null!;
}