using ZenDrivers.API.Drivers.Resources;

namespace ZenDrivers.API.Drivers.Domain.Model;

public class DriverExperience : DriverExperienceResource
{
    public Driver Driver { get; set; } = null!;
    public int DriverId { get; set; }

    public int YearsOfExperience()
    {
        var date = EndDate - StartDate;
        return (int)(date.TotalDays / 365.25);
    }
}