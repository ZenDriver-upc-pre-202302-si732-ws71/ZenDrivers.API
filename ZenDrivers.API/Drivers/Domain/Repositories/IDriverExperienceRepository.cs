using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Drivers.Domain.Repositories;

public interface IDriverExperienceRepository : ICrudRepository<DriverExperience, int>
{
    public Task<IEnumerable<DriverExperience>> FindAllByDriverId(int driverId);
}