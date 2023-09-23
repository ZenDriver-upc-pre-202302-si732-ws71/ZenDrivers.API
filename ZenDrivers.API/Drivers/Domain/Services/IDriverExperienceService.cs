using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;

namespace ZenDrivers.API.Drivers.Domain.Services;

public interface IDriverExperienceService : ICrudService<DriverExperience, int>
{
    public Task<IEnumerable<DriverExperience>> FindAllByDriverIdAsync(int driverId);
}