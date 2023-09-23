using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Services;

public class DriverExperienceService : CrudService<DriverExperience, int>, IDriverExperienceService
{
    private readonly IDriverExperienceRepository _driverExperienceRepository;
    public DriverExperienceService(IDriverExperienceRepository driverExperienceRepository, IUnitOfWork unitOfWork, IGenericMap<DriverExperience, DriverExperience> genericMap) : base(driverExperienceRepository, unitOfWork, genericMap)
    {
        _driverExperienceRepository = driverExperienceRepository;
    }

    public async Task<IEnumerable<DriverExperience>> FindAllByDriverIdAsync(int driverId)
    {
       return await _driverExperienceRepository.FindAllByDriverId(driverId);
    }
}